using AppConfig.EncryptionHandler;
using AppConfig.HelperClasses;
using BDO.Core.DataAccessObjects.CommonEntities;
using BDO.Core.DataAccessObjects.SecurityModels;
using BMCFileMangement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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
using static System.Windows.Forms.Design.AxImporter;

namespace BMCFileMangement.forms
{
    public partial class Users : Form
    {
        //private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<Users> _logger;
        private readonly IMessageService _msgService;
        private readonly IConfigurationRoot _config;
        private readonly IApplicationLogService _applog;
        private readonly IUserProfileService _userprofile;
        private readonly FtpSettingsOptions _ftpOptions;
        private readonly string ftpuser;
        private readonly string ftppassword;
        private readonly string ftpaddress;

        public Users(IConfigurationRoot config,
            ILoggerFactory loggerFactory,
            IMessageService msgService,
            IApplicationLogService applog,
            IUserProfileService userprofile,
            IOptions<FtpSettingsOptions> ftpOptions)
        {
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<Users>();
            _msgService = msgService;
            _applog = applog;
            _userprofile = userprofile;
            _ftpOptions = ftpOptions.Value;
            //_contextAccessor = contextAccessor;

            InitializeComponent();
            _loadUserDataGrid();

            ftpuser = _config.GetSection("FtpSettings").GetSection("UserName").Value;
            ftppassword = _config.GetSection("FtpSettings").GetSection("Password").Value;
            ftpaddress = _config.GetSection("FtpSettings").GetSection("FtpAddress").Value;
        }

        private void Users_Load(object sender, EventArgs e)
        {
            // _loadUser();
        }

        private void _loadUserDataGrid()
        {
            try
            {
                CancellationToken cancellationToken = new CancellationToken();
                IHttpContextAccessor httpContextAccessor = null;
                var _users = BFC.Core.FacadeCreatorObjects.Security.owin_userFCC.GetFacadeCreate(httpContextAccessor).GetAll(
                    new BDO.Core.DataAccessObjects.SecurityModels.owin_userEntity()
                    {
                        //PageSize = 10000,
                        //CurrentPage = 1
                    },
                    cancellationToken).Result;

                if (_users != null && _users.Count > 0)
                {
                    int Srno = 0;
                    var columns = from t in _users
                                  orderby t.masteruserid
                                  select new
                                  {
                                      SLNo = ++Srno,
                                      UserName = t.username,
                                      FullName = t.loweredusername,
                                      Email = t.emailaddress,
                                      Mobile = t.mobilenumber,
                                      //Folder_Path = ""
                                  };
                    //dgvUsers.DataSource = columns.ToList();
                    foreach (var user in _users)
                    {
                        dgvUsers.Rows.Add(++Srno, user.username, user.loweredusername, user.pkeyex, user.mobilenumber, user.emailaddress);
                    }
                    //for (int i = 0; i < dgvUsers.Columns.Count - 1; i++)
                    //{
                    //    dgvUsers.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //}
                    //dgvUsers.Columns[dgvUsers.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationToken cancellationToken = new CancellationToken();
                IHttpContextAccessor _contextAccessor = null;
                //if(!_validatepassword())

                (string publicKey, string privateKey) rsaKey = Encipher.GenerateRSAKeyPair();


                //Save User: Start
                Guid _userid = Guid.NewGuid();
                owin_userEntity _user = new BDO.Core.DataAccessObjects.SecurityModels.owin_userEntity()
                {
                    userid = _userid,
                    username = txtUsername.Text,
                    loweredusername = txtName.Text,
                    mobilenumber = txtMobile.Text,
                    emailaddress = txtEmail.Text,
                    password = txtPassword.Text,
                    isanonymous = false,
                    masprivatekey = rsaKey.privateKey,
                    maspublickey = rsaKey.publicKey,
                    roleid = 12, //User Role,
                    pkeyex = long.Parse(txtMobile.Text), //Mil ID
                };

                _logger.LogInformation(JsonConvert.SerializeObject(_user));
                var i = BFC.Core.FacadeCreatorObjects.Security.ExtendedPartial.FCCKAFUserSecurity.GetFacadeCreate(_contextAccessor)
                    .createuser(_user, cancellationToken);

                //Save End

                //Create Folder this user 
                if (i.Result != null && i.Result > 0)
                {
                    ftpHandler _ftp = new ftpHandler();
                    FtpSettingsOptions ftpSettingsOptions = new FtpSettingsOptions();
                    ftpSettingsOptions.ftpAddress = ftpaddress;

                    string userfolderpath = "", IN_folder = "", OUT_folder = "";
                    userfolderpath = _userid.ToString();
                    IN_folder = _userid.ToString() + "/IN";
                    OUT_folder = _userid.ToString() + "/OUT";

                    ftpSettingsOptions.user = ftpuser;
                    ftpSettingsOptions.pass = ftppassword;
                    _ftp.FolderCheckFTP(_userid.ToString(), ftpSettingsOptions);
                    _ftp.FolderCheckFTP(IN_folder, ftpSettingsOptions);
                    _ftp.FolderCheckFTP(OUT_folder, ftpSettingsOptions);

                    MessageBox.Show("User create succesfully");
                }
                else
                {
                    MessageBox.Show("User create failed");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private bool _validatepassword()
        {
            if (txtPassword.PasswordChar.Equals(txtConfirmPassword.PasswordChar)) return true;
            else return false;
        }



        //private void txtConfirmPassword_Leave(object sender, EventArgs e)
        //{


        //}

        //private void txtConfirmPassword_MouseUp(object sender, MouseEventArgs e)
        //{

        //}

        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            //if (!txtPassword.Text.Equals(txtConfirmPassword.Text)) errorProvider3.SetError(this.label2, "Password mismatch");
            //else errorProvider3.Clear();
        }

    }
}
