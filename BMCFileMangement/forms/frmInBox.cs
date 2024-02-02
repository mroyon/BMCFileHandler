using BMCFileMangement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMCFileMangement.forms
{
    public partial class frmInBox : Form
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<frmMainWindow> _logger;
        private readonly IMessageService _msgService;
        private readonly IConfigurationRoot _config;
        private readonly IApplicationLogService _applog;
        private readonly IUserProfileService _userprofile;
        private readonly IFileNotificationService _fileNotificationList;
        private readonly string rootdirectorypath;
        private readonly IFTPTransferService _fTPTransferService;
        private readonly string myfolderid;

        
        public frmInBox(IConfigurationRoot config,
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
            rootdirectorypath = _config.GetSection("UserDirectorySetting").GetSection("root").Value;
            myfolderid = _config.GetSection("UserDirectorySetting").GetSection("myfolderid").Value;
            InitializeComponent();
            InitializeComponent2();
            LoadTransFiles();
        }


        public void InitializeComponent2()
        {
            dtGrdInBox.AutoGenerateColumns = false;

            dtGrdInBox.Columns.Add("fromusername", "From User");
            dtGrdInBox.Columns.Add("sentdate", "Sent Date");
            dtGrdInBox.Columns.Add("filename", "File Name");
            dtGrdInBox.Columns.Add("priority", "Priority");
            dtGrdInBox.Columns.Add("fromuserremark", "Remarks");

            dtGrdInBox.Columns["fromusername"].DataPropertyName = "fromusername";
            dtGrdInBox.Columns["sentdate"].DataPropertyName = "sentdate";
            dtGrdInBox.Columns["filename"].DataPropertyName = "filename";
            dtGrdInBox.Columns["priority"].DataPropertyName = "priority";
            dtGrdInBox.Columns["fromuserremark"].DataPropertyName = "fromuserremark";
        }

        public void LoadTransFiles()
        {

            string Dir = rootdirectorypath;
        }

    }
}
