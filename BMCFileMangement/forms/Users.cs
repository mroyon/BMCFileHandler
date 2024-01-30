using AppConfig.EncryptionHandler;
using BDO.Core.DataAccessObjects.SecurityModels;
using BMCFileMangement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
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
        public Users(IConfigurationRoot config,
            ILoggerFactory loggerFactory,
            IMessageService msgService,
            IApplicationLogService applog,
            IUserProfileService userprofile)
        {
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<Users>();
            _msgService = msgService;
            _applog = applog;
            _userprofile = userprofile;
            //_contextAccessor = contextAccessor;

            InitializeComponent();
            _loadUserDataGrid();
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
                                      Sl_no = ++Srno,
                                      User_Name = t.username,
                                      Name = t.loweredusername,
                                      Email_Address = t.emailaddress,
                                      Mobile_Number = t.mobilenumber,
                                      Folder_Path = ""
                                  };
                    dgvUsers.DataSource = columns.ToList();

                    for (int i = 0; i < dgvUsers.Columns.Count - 1; i++)
                    {
                        dgvUsers.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    dgvUsers.Columns[dgvUsers.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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

                owin_userEntity _user = new BDO.Core.DataAccessObjects.SecurityModels.owin_userEntity()
                {
                    userid = new Guid(),
                    username = txtUsername.Text,
                    loweredusername = txtName.Text,
                    mobilenumber = txtMobile.Text,
                    emailaddress = txtEmail.Text,
                    password = txtPassword.Text,
                    isanonymous = false,
                    masprivatekey = rsaKey.privateKey,
                    maspublickey = rsaKey.publicKey,
                    roleid = 12, //User Role,
                    pkeyex = null, //Mil ID
                };

                _logger.LogInformation(JsonConvert.SerializeObject(_user));
                var i = BFC.Core.FacadeCreatorObjects.Security.ExtendedPartial.FCCKAFUserSecurity.GetFacadeCreate(_contextAccessor)
                    .createuser(_user, cancellationToken);
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
            if (!txtPassword.Text.Equals(txtConfirmPassword.Text)) errorProvider3.SetError(this.label2, "Password mismatch");
            else errorProvider3.Clear();
        }
    }
}
