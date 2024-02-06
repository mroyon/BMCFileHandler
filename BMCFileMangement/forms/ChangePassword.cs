using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.SecurityModels;
using BMCFileMangement.Services.DisServices;
using BMCFileMangement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMCFileMangement.forms
{
    public partial class ChangePassword : Form
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
        public ChangePassword(IConfigurationRoot config,
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
            btnChangePassword.Click += btnChangePassword_Click;
            txtUserName.Text = _userprofile.CurrentUser.username;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter old password"); return;
            }
            else if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                MessageBox.Show("Please enter new password"); return;
            }
            else if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please enter confirm password"); return;
            }
            else if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password mismatched"); return;
            }

            owin_userEntity request = new owin_userEntity();
            request.username = _userprofile.CurrentUser.username;
            request.userid = _userprofile.CurrentUser.userid;
            request.emailaddress = _userprofile.CurrentUser.useremail;
            request.password = txtPassword.Text;
            request.newpassword = txtNewPassword.Text;
            request.confirmpassword = txtConfirmPassword.Text;

            clsSecurityCapsule objCap = new clsSecurityCapsule();
            request.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
            request.BaseSecurityParam = objCap.GetSecurityCapsule(dt, _userprofile.CurrentUser.username);
            objCap.Dispose();

            CancellationToken cancellationToken = new CancellationToken();
            IHttpContextAccessor httpContextAccessor = null;
            owin_userEntity _user = BFC.Core.FacadeCreatorObjects.Security.ExtendedPartial.FCCKAFUserSecurity.
                       GetFacadeCreate(httpContextAccessor).ChangePasswordRequest(request, cancellationToken).Result;

            if (_user != null)
            {
                txtPassword.Text = "";
                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";

                MessageBox.Show("Password has been changed successfully");
            }
            else
            {
                MessageBox.Show("Error! Password change failed");
            }
        }
    }
}
