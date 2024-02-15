using BDO.Core.DataAccessObjects.ExtendedEntities;
using BMCFileMangement.helper;
using BMCFileMangement.Services.Interface;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Validation;
using DocumentFormat.OpenXml;
using HtmlToOpenXml;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using DocumentFormat.OpenXml.Wordprocessing;
using BDO.Core.DataAccessObjects.Models;
using CLL.LLClasses.Models;
using System.Threading;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace BMCFileMangement.forms
{
    public partial class frmFileSendEdit : Form
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();


        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<frmMainWindow> _logger;
        private readonly IMessageService _msgService;
        private readonly IConfigurationRoot _config;
        private readonly IApplicationLogService _applog;
        private readonly IUserProfileService _userprofile;
        private readonly IFileNotificationService _fileNotificationList;
        private readonly IFTPTransferService _fTPTransferService;
        private readonly FtpSettings _ftpSettings;
        private readonly filetransferinfoEntity _filetransferinfo;

        public frmFileSendEdit(
            filetransferinfoEntity filetransferinfo,
            IConfigurationRoot config,
            ILoggerFactory loggerFactory,
            IMessageService msgService,
            IApplicationLogService applog,
            IUserProfileService userprofile,
            IFileNotificationService fileNotificationList,
            IFTPTransferService fTPTransferService)
        {
            InitializeComponent();
            _filetransferinfo = filetransferinfo;
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<frmMainWindow>();
            _msgService = msgService;
            _applog = applog;
            _fileNotificationList = fileNotificationList;
            _fTPTransferService = fTPTransferService;

            _userprofile = userprofile;
            _ftpSettings = _config.GetSection(nameof(FtpSettings)).Get<FtpSettings>();

            btnSendFile.Click += btnSendFile_Click;
            _LoadUser();
            _loadPriority();
            //tinyMceEditor.CreateEditor();

            //myTimer.Tick += new EventHandler(TimerEventProcessor);
            //// Sets the timer interval to 5 seconds.
            //myTimer.Interval = 200;
            //myTimer.Start();

            var workingArea = Screen.FromHandle(Handle).WorkingArea;
            this.MaximizedBounds = new Rectangle(0, 0, workingArea.Width, workingArea.Height);
            WindowState = FormWindowState.Maximized;
        }

        private void TimerEventProcessor(object? sender, EventArgs e)
        {
            //if (tinyMceEditor.checkif())
            //{
            //    myTimer.Stop();
            //    _getInboxData();
            //}
        }

        private void frmFileSendEdit_Load(object sender, EventArgs e)
        {

        }
        private void btnSendFile_Click(object sender, EventArgs e)
        {

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
        private void _getInboxData()
        {
            CancellationToken cancellationToken = new CancellationToken();
            IHttpContextAccessor httpContextAccessor = null;

            try
            {
                var obj = BFC.Core.FacadeCreatorObjects.General.filetransferinfoFCC.GetFacadeCreate(httpContextAccessor).GetSingle(
                        new filetransferinfoEntity()
                        {
                            filetransid = _filetransferinfo.filetransid
                        }, cancellationToken).Result;

                if (obj != null)
                {
                    //string fileSubPath = _userprofile.CurrentUser.userid.GetValueOrDefault().ToString() + "/OUTBOX/" + obj.fromuserremark;
                    ////string fileFullPath = $"{_ftpSettings.FtpAddress}{fileSubPath}";
                    //var fileStream = _fTPTransferService.DownloadFile_FileStream(fileSubPath).Result;
                    //string contents;
                    //using (var sr = new StreamReader(fileStream))
                    //{
                    //    contents = sr.ReadToEnd();
                    //}
                    //Task.Delay(2000);
                    string filename = ConvertHtmlContentToDocX(obj.documentblock);
                    tinyMceEditor.HtmlContent = obj.documentblock;//File.ReadAllText(filename);


                    tinyMceEditor.HtmlContent = obj.documentblock;
                    //cboPriority.SelectedValue = obj.priority;
                    int index = cboPriority.Items.IndexOf(obj.priority);

                    var itemPriority = cboPriority.Items.Cast<gen_dropdownEntity>().FirstOrDefault(x => x.Id == obj.priority);
                    cboPriority.SelectedIndex = cboPriority.Items.IndexOf(itemPriority); 

                    var itemuser = cboUser.Items.Cast<gen_dropdownEntity>().FirstOrDefault(x => x.strValue1 == obj.fromuserid.ToString());
                    cboUser.SelectedIndex = cboUser.Items.IndexOf(itemuser); 
                }
            }
            catch (Exception ex)
            {

            }
        }
        private int GetIndexById(ComboBox comboBox, string id)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                gen_dropdownEntity item = (gen_dropdownEntity)comboBox.Items[i];

                if (item.Id.ToString() == id)
                {
                    return i; 
                }
            }
            return -1; 
        }

        private string _getFile(string _filename, string _htmlContent)
        {
            string filename = "test.docx";
            string html = _htmlContent;//"<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html>\r\n<head>\r\n<title>Untitled document</title>\r\n</head>\r\n<body>\r\n<p><span>\r\n<p dir=\"ltr\" align=\"center\">Sample Letter</p>\r\n<em>\r\n<p dir=\"ltr\" align=\"left\">(Name of Company/Person)<br />(Address)<br /><br />(Today&rsquo;s date)</p>\r\n</em><br /><br /><br />Re: Request that　 my record be updated to reflect my changed name<br /><br /><br />Dear XXXXX,<br /><br />Please change my record to reflect my new name. <br /><br />My account number is ____________________. <br />My Social Security number is _____________________.<em>(Include this only if necessary to identify you)</em><br /><br />My former name is <em>(former name)</em>. However, as of (<em>date of court order or date you decided to assume your new name)</em>, my new name is (<em>New Name). </em><br /><br /><span style=\"color: #ff0000;\">Please make modify my records with you as soon as possible. I am enclosing copy of the court order. (<em>Delete this sentence if not appropriate.) </em><br /></span><br />If there are any questions regarding the change of my name, please contact me immediately. During the day I can best be reached by <em>(fill in how you want to be reached and the hours if appropriate) <br /></em><br />Thank you for your assistance. I would appreciate written confirmation that you have acted upon my request.<br /><br /><br />Sincerely,<br /><br /><br /><br /><em>(New Name &ndash; written and typed)</em> formerly known as <em>(Former Name &ndash; written and typed)</em><br /><em>(Address)</em><br />(<em>Email)</em><br /><em>(Phone) </em>\r\n<p dir=\"ltr\" align=\"left\">&nbsp;</p>\r\n</span></p>\r\n</body>\r\n</html>";//ResourceHelper.GetString("Resources.CompleteRunTest.html");
            if (File.Exists(filename)) File.Delete(filename);
            
            string fileSubPath = _userprofile.CurrentUser.userid.GetValueOrDefault().ToString() + "/OUTBOX/" + _filename;
            var fileStream = _fTPTransferService.DownloadFile_FileStream(fileSubPath).Result;

            using (MemoryStream generatedDocument = new MemoryStream())
            {
                // Uncomment and comment the second using() to open an existing template document
                // instead of creating it from scratch.
                using (var buffer = _fTPTransferService.DownloadFile_FileStream(fileSubPath).Result)
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

        private void frmFileSendEdit_Load_1(object sender, EventArgs e)
        {
            tinyMceEditor.CreateEditor();
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _getInboxData();
        }
    }
}
