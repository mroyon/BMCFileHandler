using AppConfig.HelperClasses;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using BDO.DataAccessObjects.ExtendedEntities;
using BMCFileMangement.Services.DisServices;
using BMCFileMangement.Services.Interface;
using CLL.LLClasses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
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
        private readonly IFileNotificationService _fileNotificationList;
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
        /// <param name="fileNotificationList"></param>
        /// <param name="fTPTransferService"></param>
        public frmFileSend(IConfigurationRoot config,
            ILoggerFactory loggerFactory,
            IMessageService msgService,
            IApplicationLogService applog,
            IUserProfileService userprofile,
            IFileNotificationService fileNotificationList,
            IFTPTransferService fTPTransferService)
        {
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<frmMainWindow>();
            _msgService = msgService;
            _applog = applog;
            _fileNotificationList = fileNotificationList;
            _fTPTransferService = fTPTransferService;

            _userprofile = userprofile;
            _ftpSettings = _config.GetSection(nameof(FtpSettings)).Get<FtpSettings>();
            InitializeComponent();

            btnBrowseFile.Click += btnBrowseFile_Click;
            btnSendFile.Click += btnSendFile_Click;
            _LoadUser();
            _loadPriority();
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

            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("Please select file");
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
                string sourcepath = txtFilePath.Text.Trim();
                string fileName = Path.GetFileName(sourcepath);

                int maxId = 1;
                string TempNewName = "";

                FileInfo _file = new FileInfo(sourcepath);
                CustomFileClassEntity fileDetails = new CustomFileClassEntity(_file);
                string jsonFile = JsonConvert.SerializeObject(fileDetails);

                bool isUploadedFile = false;

                

                try
                {

                    var obj =  BFC.Core.FacadeCreatorObjects.General.filetransferinfoFCC.GetFacadeCreate(httpContextAccessor).GetAll(
                        new filetransferinfoEntity()
                        {
                            filename = fileName
                        }, cancellationToken).Result;

                    if(obj != null && obj.Count >0)
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
                        filename = fileName,//Path.GetFileName(desPath),
                        fileversion = maxId,
                        fullpath = _ftpSettings.FtpAddress + cboUser.SelectedValue.ToString() + "/INBOX/",
                        priority = Convert.ToInt32(cboPriority.SelectedValue),
                        filejsondata = jsonFile,
                        status = 1,
                        expecteddate = dt
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



        private void frmFileSend_Load(object sender, EventArgs e)
        {

        }
    }


}
