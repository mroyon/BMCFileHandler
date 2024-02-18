using AppConfig.HelperClasses;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using BDO.DataAccessObjects.ExtendedEntities;
using BMCFileMangement.helper;
using BMCFileMangement.Services.DisServices;
using BMCFileMangement.Services.Interface;
using CLL.LLClasses.Models;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Validation;
using DocumentFormat.OpenXml.Wordprocessing;
using HtmlToOpenXml;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using static AppConfig.HelperClasses.clsPrivateKeys;


namespace BMCFileMangement.forms
{
    public partial class frmFileSend : Form
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<frmMainWindow> _logger;
        private readonly IMessageService _msgService;
        private readonly IConfigurationRoot _config;
        private readonly IApplicationLogService _applog;
        private readonly IUserProfileService _userprofile;
        private readonly IFTPTransferService _fTPTransferService;
        private readonly FtpSettings _ftpSettings;

        /// <summary>
        /// frmFileSend
        /// </summary>
        /// <param name="config"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="msgService"></param>
        /// <param name="applog"></param>
        /// <param name="userprofile"></param>
        /// <param name="fTPTransferService"></param>
        public frmFileSend(IConfigurationRoot config,
            ILoggerFactory loggerFactory,
            IMessageService msgService,
            IApplicationLogService applog,
            IUserProfileService userprofile,
            IFTPTransferService fTPTransferService)
        {
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<frmMainWindow>();
            _msgService = msgService;
            _applog = applog;
            _fTPTransferService = fTPTransferService;

            _userprofile = userprofile;
            _ftpSettings = _config.GetSection(nameof(FtpSettings)).Get<FtpSettings>();
            InitializeComponent();

            btnBrowseFile.Click += btnBrowseFile_Click;
            btnSendFile.Click += btnSendFile_Click;
            _LoadUser();
            _loadPriority();
            tinyMceEditor.CreateEditor();
        }


        private void _LoadUser()
        {
            try
            {
                CancellationToken cancellationToken = new CancellationToken();
                IHttpContextAccessor httpContextAccessor = null;
                var _users = BFC.Core.FacadeCreatorObjects.Security.owin_userFCC.GetFacadeCreate(httpContextAccessor).GetDataForDropDown(

                    new BDO.Core.DataAccessObjects.SecurityModels.owin_userEntity()
                    {
                        PageSize = 10000,
                        CurrentPage = 1,
                        username = _userprofile.CurrentUser.username
                    },
                    cancellationToken).Result;

                if (_users != null && _users.Count > 0)
                {
                    gen_dropdownEntity us = new gen_dropdownEntity();
                    us.strValue1 = "-99";
                    us.Text = "Please select user";
                    _users.Add(us);

                    cboUser.DataSource = _users;
                    cboUser.ValueMember = "strValue1";
                    cboUser.DisplayMember = "Text";
                    cboUser.SelectedIndex = cboUser.Items.Count - 1;

                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void _loadPriority()
        {
            List<gen_dropdownEntity> _priority = new List<gen_dropdownEntity>();
            _priority.Add(new gen_dropdownEntity { Id = -99, Text = "Please select priority" });
            _priority.Add(new gen_dropdownEntity { Id = 1, Text = "High" });
            _priority.Add(new gen_dropdownEntity { Id = 2, Text = "Medium" });
            _priority.Add(new gen_dropdownEntity { Id = 3, Text = "Low" });

            cboPriority.DataSource = _priority;
            cboPriority.ValueMember = "Id";
            cboPriority.DisplayMember = "Text";
            cboPriority.SelectedIndex = 0;
        }
        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fdlg = new OpenFileDialog();
                fdlg.Title = "Select file";
                fdlg.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
                fdlg.Filter = string.Format("{0}{1}{2} ({3})|{3}", fdlg.Filter, "", "All Files", "*.*");
                // Code for image filter  
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                foreach (ImageCodecInfo c in codecs)
                {
                    string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                    fdlg.Filter = string.Format("{0}{1}{2} ({3})|{3}", fdlg.Filter, "|", codecName, c.FilenameExtension);
                }
                // Code for files filter  
                fdlg.Filter = fdlg.Filter + "|CSV Files (*.csv)|*.csv";
                fdlg.Filter = fdlg.Filter + "|Excel Files (.xls ,.xlsx)|  *.xls ;*.xlsx";
                fdlg.Filter = fdlg.Filter + "|PDF Files (.pdf)|*.pdf";
                fdlg.Filter = fdlg.Filter + "|Text Files (*.txt)|*.txt";
                fdlg.Filter = fdlg.Filter + "|Word Files (.docx ,.doc)|*.docx;*.doc";
                fdlg.Filter = fdlg.Filter + "|XML Files (*.xml)|*.xml";

                fdlg.FilterIndex = 1;
                fdlg.RestoreDirectory = true;
                fdlg.Multiselect = true;
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = fdlg.FileName;
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            CancellationToken cancellationToken = new CancellationToken();
            IHttpContextAccessor httpContextAccessor = null;

            if (string.IsNullOrEmpty(txtFilePath.Text) && string.IsNullOrEmpty(tinyMceEditor.HtmlContent))
            {
                MessageBox.Show("Please select file or create file");
                return;
            }

            if (cboUser.SelectedValue == "-99")
            {
                MessageBox.Show("Please select user");
                return;
            }

            if (cboPriority.SelectedValue.ToString() == "-99")
            {
                MessageBox.Show("Please select priority");
                return;
            }

            // Display a confirmation message box
            DialogResult result = MessageBox.Show("Are you sure you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                DateTime dt = DateTime.Now;
                int maxId = 1;
                string TempNewName = "";
                bool isUploadedFile = false;
                string jsonFile = "";
                string fileName = "";

                #region Upload File from File dialog
                if (!string.IsNullOrEmpty(txtFilePath.Text.Trim()))
                {
                    string sourcepath = txtFilePath.Text.Trim();
                    //string fileName = Path.GetFileName(sourcepath);
                    

                    fileName = Path.GetFileName(sourcepath);
                    FileInfo _file = new FileInfo(sourcepath);
                    CustomFileClassEntity fileDetails = new CustomFileClassEntity(_file);
                    jsonFile = JsonConvert.SerializeObject(fileDetails);
                    
                    try
                    {
                        var obj = BFC.Core.FacadeCreatorObjects.General.filetransferinfoFCC.GetFacadeCreate(httpContextAccessor).GetAll(
                            new filetransferinfoEntity()
                            {
                                filename = fileName
                            }, cancellationToken).Result;

                        if (obj != null && obj.Count > 0)
                        {
                            maxId = obj.Max(item => item.fileversion.GetValueOrDefault());
                            maxId += 1;

                        }

                        // Upload file into Sender OUTBOX: Start
                        var sOutboxPath = $"{_userprofile.CurrentUser.userid.GetValueOrDefault().ToString()}/OUTBOX/";
                        var _SenderUploadfile = _fTPTransferService.UploadFile(sourcepath, sOutboxPath, maxId.ToString() + "_" + fileName);
                        // Upload file into Sender OUTBOX: END

                        // Upload file into Receiver INBOX: Start
                        var rInboxPath = $"{cboUser.SelectedValue.ToString()}/INBOX/";
                        var _ReceiverUploadfile = _fTPTransferService.UploadFile(sourcepath, rInboxPath, maxId.ToString() + "_" + fileName);
                        // Upload file into Receiver INBOX: END
                        isUploadedFile = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        isUploadedFile = false;
                    }
                }
                #endregion

                #region Upload File from TinyMCE Content
                if (!string.IsNullOrEmpty(tinyMceEditor.HtmlContent))
                {
                    AppConfig.HelperClasses.transactioncodeGen transactioncodeGen = new AppConfig.HelperClasses.transactioncodeGen();
                    fileName = transactioncodeGen.GetRandomAlphaNumericString(8) + ".docx";

                    string sFilePath = ConvertHtmlContentToDocX(tinyMceEditor.HtmlContent);
                    try
                    {
                        // Upload file into Sender OUTBOX: Start
                        var sOutboxPath = $"{_userprofile.CurrentUser.userid.GetValueOrDefault().ToString()}/OUTBOX/";
                        var _SenderUploadfile = _fTPTransferService.UploadFile(sFilePath, sOutboxPath, fileName);
                        // Upload file into Sender OUTBOX: END

                        // Upload file into Receiver INBOX: Start
                        var rInboxPath = $"{cboUser.SelectedValue.ToString()}/INBOX/";
                        var _ReceiverUploadfile = _fTPTransferService.UploadFile(sFilePath, rInboxPath, fileName);
                        // Upload file into Receiver INBOX: END
                        isUploadedFile = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        isUploadedFile = false;
                    }
                }
                #endregion
                //Upload File into FTP 
                if (isUploadedFile)
                {
                   
                    filetransferinfoEntity objFileInBox = new filetransferinfoEntity()
                    {
                        fromusername = _userprofile.CurrentUser.username,
                        fromuserid = _userprofile.CurrentUser.userid,
                        tousername = cboUser.GetItemText(cboUser.SelectedItem),
                        touserid = new Guid(cboUser.SelectedValue.ToString()),
                        fromuserremark = txtRemarks.Text,
                        sentdate = dt,
                        showedpopup = false,
                        showeddate = null,
                        isreceived = true,
                        receiveddate = dt,
                        isopen = false,
                        opendate = null,
                        filename = maxId.ToString() + "_" + fileName,//Path.GetFileName(desPath),
                        fileversion = maxId,
                        fullpath = _ftpSettings.FtpAddress + cboUser.SelectedValue.ToString() + "/INBOX/",
                        priority = Convert.ToInt32(cboPriority.SelectedValue),
                        filejsondata = jsonFile,
                        status = 1,
                        expecteddate = dt,
                        documentblock = tinyMceEditor.HtmlContent
                    };

                    clsSecurityCapsule objCap = new clsSecurityCapsule();

                    objFileInBox.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                    objFileInBox.BaseSecurityParam = objCap.GetSecurityCapsule(dt, _userprofile.CurrentUser.username);
                    objCap.Dispose();
                    var _filetrans = BFC.Core.FacadeCreatorObjects.General.filetransferinfoFCC.
                        GetFacadeCreate(httpContextAccessor).Add(objFileInBox,cancellationToken);

                    if (_filetrans.Result > 0)
                    {
                        
                        txtFilePath.Text = "";
                        cboUser.SelectedIndex = 0;
                        txtRemarks.Text = "";
                        MessageBox.Show("Data sent successfully");
                        
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Data sent failed");
                    }
                }
            }
            else
            {
                // User clicked No, do nothing or handle accordingly
                MessageBox.Show("Action canceled!");
            }

        }

        private string ConvertHtmlContentToDocX(string _htmlContent)
        {
            string filename = "test.docx";
            string html = _htmlContent;//"<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html>\r\n<head>\r\n<title>Untitled document</title>\r\n</head>\r\n<body>\r\n<p><span>\r\n<p dir=\"ltr\" align=\"center\">Sample Letter</p>\r\n<em>\r\n<p dir=\"ltr\" align=\"left\">(Name of Company/Person)<br />(Address)<br /><br />(Today&rsquo;s date)</p>\r\n</em><br /><br /><br />Re: Request that　 my record be updated to reflect my changed name<br /><br /><br />Dear XXXXX,<br /><br />Please change my record to reflect my new name. <br /><br />My account number is ____________________. <br />My Social Security number is _____________________.<em>(Include this only if necessary to identify you)</em><br /><br />My former name is <em>(former name)</em>. However, as of (<em>date of court order or date you decided to assume your new name)</em>, my new name is (<em>New Name). </em><br /><br /><span style=\"color: #ff0000;\">Please make modify my records with you as soon as possible. I am enclosing copy of the court order. (<em>Delete this sentence if not appropriate.) </em><br /></span><br />If there are any questions regarding the change of my name, please contact me immediately. During the day I can best be reached by <em>(fill in how you want to be reached and the hours if appropriate) <br /></em><br />Thank you for your assistance. I would appreciate written confirmation that you have acted upon my request.<br /><br /><br />Sincerely,<br /><br /><br /><br /><em>(New Name &ndash; written and typed)</em> formerly known as <em>(Former Name &ndash; written and typed)</em><br /><em>(Address)</em><br />(<em>Email)</em><br /><em>(Phone) </em>\r\n<p dir=\"ltr\" align=\"left\">&nbsp;</p>\r\n</span></p>\r\n</body>\r\n</html>";//ResourceHelper.GetString("Resources.CompleteRunTest.html");
            if (File.Exists(filename)) File.Delete(filename);

            using (MemoryStream generatedDocument = new MemoryStream())
            {
                // Uncomment and comment the second using() to open an existing template document
                // instead of creating it from scratch.
                using (var buffer = ResourceHelper.GetStream("Resources.template.docx"))
                {
                    buffer.CopyTo(generatedDocument);
                }

                generatedDocument.Position = 0L;
                using (WordprocessingDocument package = WordprocessingDocument.Open(generatedDocument, true))
                //using (WordprocessingDocument package = WordprocessingDocument.Create(generatedDocument, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = package.MainDocumentPart;
                    if (mainPart == null)
                    {
                        mainPart = package.AddMainDocumentPart();
                        new Document(new Body()).Save(mainPart);
                    }

                    HtmlConverter converter = new HtmlConverter(mainPart);
                    Body body = mainPart.Document.Body;

                    converter.ParseHtml(html);
                    mainPart.Document.Save();

                    AssertThatOpenXmlDocumentIsValid(package);
                }

                File.WriteAllBytes(filename, generatedDocument.ToArray());
            }

            //Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });

            return filename;
        }
        static void AssertThatOpenXmlDocumentIsValid(WordprocessingDocument wpDoc)
        {
            var validator = new OpenXmlValidator(FileFormatVersions.Office2021);
            var errors = validator.Validate(wpDoc);

            if (!errors.GetEnumerator().MoveNext())
                return;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The document doesn't look 100% compatible with Office 2021.\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (ValidationErrorInfo error in errors)
            {
                Console.Write("{0}\n\t{1}", error.Path.XPath, error.Description);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
        private void frmFileSend_Load(object sender, EventArgs e)
        {

        }
    }


}
