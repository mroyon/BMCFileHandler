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
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;
using Image = System.Drawing.Image;

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
        private readonly DataGridViewImageColumn btnImgGridEdit;
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
            btnImgGridEdit = new DataGridViewImageColumn();
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

                dgvUsers.Rows.Clear();
                dgvUsers.Refresh();
                //btnImgGridEdit = new DataGridViewImageColumn();
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

                    foreach (var user in _users)
                    {
                        dgvUsers.Rows.Add(++Srno, user.userid, user.username, user.loweredusername, user.pkeyex, user.emailaddress);
                    }


                    //Image image = Properties.Resources.edit;
                    //btnImgGridEdit.Image = image;
                    //dgvUsers.Columns.Add(btnImgGridEdit);
                    ////img2.HeaderText = "Edit";
                    //btnImgGridEdit.Name = "Edit";
                    //btnImgGridEdit.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    //btnImgGridEdit.Width = 60;



                    //img2.eg = 12;
                    //dgvUsers.CellFormatting += DataGridView1_CellFormatting;

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
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvUsers.Columns["customButtonColumn"].Index)
            {
                // Set the image for the button
                e.Value = Properties.Resources.programer01;
            }
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationToken cancellationToken = new CancellationToken();
                IHttpContextAccessor _contextAccessor = null;
                //if(!_validatepassword())

                if (btnAddUser.Text == "Update User" && !string.IsNullOrEmpty(txtUserID.Text))
                {
                    owin_userEntity _user = new BDO.Core.DataAccessObjects.SecurityModels.owin_userEntity()
                    {
                        userid = new Guid(txtUserID.Text),
                        username = txtUsername.Text,
                        loweredusername = txtName.Text,
                        emailaddress = txtEmail.Text,
                        pkeyex = long.Parse(txtMilitaryNo.Text)
                    };
                    _logger.LogInformation(JsonConvert.SerializeObject(_user));
                    var i = BFC.Core.FacadeCreatorObjects.Security.owin_userFCC.GetFacadeCreate(_contextAccessor)
                        .Update(_user, cancellationToken);
                    if (i.Result != null && i.Result > 0)
                    {
                        MessageBox.Show("User update succesfully");
                        _clearControl();
                        _loadUserDataGrid();
                    }
                    else
                        MessageBox.Show("User update failed");
                }
                else
                {
                    (string publicKey, string privateKey) rsaKey = Encipher.GenerateRSAKeyPair();
                    //Save User: Start
                    Guid _userid = Guid.NewGuid();
                    owin_userEntity _user = new BDO.Core.DataAccessObjects.SecurityModels.owin_userEntity()
                    {
                        userid = _userid,
                        username = txtUsername.Text,
                        loweredusername = txtName.Text,
                        mobilenumber = "00000000",
                        emailaddress = txtEmail.Text,
                        password = txtPassword.Text,
                        isanonymous = false,
                        masprivatekey = rsaKey.privateKey,
                        maspublickey = rsaKey.publicKey,
                        roleid = 12, //User Role,
                        pkeyex = long.Parse(txtMilitaryNo.Text), //Mil ID
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
                        _clearControl();
                        _loadUserDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("User create failed");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private bool _validatepassword()
        {
            if (txtPassword.PasswordChar.Equals(txtConfirmPassword.PasswordChar)) return true;
            else return false;
        }


        private void _clearControl()
        {
            if (btnAddUser.Text == "Update User") { btnAddUser.Text = "Add User"; btnAddUser.IconChar = FontAwesome.Sharp.IconChar.PlusCircle; }
            txtUserID.Clear();
            txtUsername.Clear();
            txtName.Clear();
            txtMilitaryNo.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            dgvUsers.Rows.Clear();
            dgvUsers.Refresh();
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

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6) //if Edit Button
            {
                txtUserID.Text = dgvUsers.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtUsername.Text = dgvUsers.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtName.Text = dgvUsers.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtMilitaryNo.Text = dgvUsers.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtEmail.Text = dgvUsers.Rows[e.RowIndex].Cells[5].Value.ToString();

                txtPassword.ReadOnly = true;
                txtConfirmPassword.ReadOnly = true;

                btnAddUser.Text = "Update User";
                btnAddUser.IconChar = FontAwesome.Sharp.IconChar.Edit;
                
               // MessageBox.Show("EDIT button clicked at row: " + e.RowIndex);
            }
        }
    }
}
