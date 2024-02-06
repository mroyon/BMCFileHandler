using AppConfig.EncryptionHandler;
using AppConfig.HelperClasses;
using BDO.Core.DataAccessObjects.CommonEntities;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using BDO.DataAccessObjects.ExtendedEntities;
using BMCFileMangement.Services.DisServices;
using BMCFileMangement.Services.Implementation;
using BMCFileMangement.Services.Interface;
using FontAwesome.Sharp;
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
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;
using Button = System.Windows.Forms.Button;
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
        //private readonly FtpSettingsOptions _ftpOptions;
        //private readonly string ftpuser;
        //private readonly string ftppassword;
        //private readonly string ftpaddress;
        private readonly DataGridViewImageColumn btnImgGridEdit;
        private readonly IFTPTransferService _fTPTransferService;
        private readonly FtpSettings _ftpSettings;


        private int PageSize = 10;
        private int CurrentPage = 1;
        private int TotalPage = 0;


        public Users(IConfigurationRoot config,
            ILoggerFactory loggerFactory,
            IMessageService msgService,
            IApplicationLogService applog,
            IUserProfileService userprofile,
            IOptions<FtpSettingsOptions> ftpOptions,
            IFTPTransferService fTPTransferService)
        {
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<Users>();
            _msgService = msgService;
            _applog = applog;
            _userprofile = userprofile;
            btnImgGridEdit = new DataGridViewImageColumn();
            InitializeComponent();
            //_loadUserDataGrid();
            //BindDataToGrid(1, 10);
            BindGrid(CurrentPage);
            _fTPTransferService = fTPTransferService;
            _ftpSettings = _config.GetSection(nameof(FtpSettings)).Get<FtpSettings>();
            btnAddUser.Click += BtnAddUser_Click;
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
        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                CancellationToken cancellationToken = new CancellationToken();
                IHttpContextAccessor _contextAccessor = null;
                //if(!_validatepassword())
                DateTime dt = DateTime.Now;

                if (string.IsNullOrEmpty(txtUsername.Text)) { MessageBox.Show("Please enter user name"); return; }
                if (string.IsNullOrEmpty(txtName.Text)) { MessageBox.Show("Please enter name"); return; }
                if (string.IsNullOrEmpty(txtMilitaryNo.Text)) { MessageBox.Show("Please enter military no"); return; }
                if (string.IsNullOrEmpty(txtEmail.Text)) { MessageBox.Show("Please enter email address"); return; }
                if (string.IsNullOrEmpty(txtPassword.Text)) { MessageBox.Show("Please enter password"); return; }
                if (string.IsNullOrEmpty(txtConfirmPassword.Text)) { MessageBox.Show("Please enter confirm password"); return; }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Password mismatched"); return;
                }

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

                    clsSecurityCapsule objCap = new clsSecurityCapsule();

                    _user.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                    _user.BaseSecurityParam = objCap.GetSecurityCapsule(dt, _userprofile.CurrentUser.username);
                    objCap.Dispose();
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

                    clsSecurityCapsule objCap = new clsSecurityCapsule();

                    _user.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                    _user.BaseSecurityParam = objCap.GetSecurityCapsule(dt, _userprofile.CurrentUser.username);
                    objCap.Dispose();

                    _logger.LogInformation(JsonConvert.SerializeObject(_user));
                    var i = BFC.Core.FacadeCreatorObjects.Security.ExtendedPartial.FCCKAFUserSecurity.GetFacadeCreate(_contextAccessor)
                        .createuser(_user, cancellationToken);

                    //Save End

                    //Create Folder this user 
                    if (i.Result != null && i.Result > 0)
                    {
                        string userfolderpath = "", IN_folder = "", OUT_folder = "";
                        userfolderpath = _userid.ToString();
                        IN_folder = _userid.ToString() + "/INBOX";
                        OUT_folder = _userid.ToString() + "/OUTBOX";

                        long retValue = 0;
                        if (_fTPTransferService.CreateUserFTPDir(userfolderpath) == "Folder created successfully.")
                        {
                            _fTPTransferService.CreateUserFTPDir(IN_folder);
                            _fTPTransferService.CreateUserFTPDir(OUT_folder);

                            retValue = _SaveFolderStructure(_userid.ToString(), userfolderpath);
                        }
                        MessageBox.Show("User create succesfully");
                        _clearControl();
                        //_loadUserDataGrid();
                        BindGrid(CurrentPage);
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

        private long _SaveFolderStructure(string userid, string folderpath)
        {
            long result = 0;
            try
            {
                CancellationToken cancellationToken = new CancellationToken();
                IHttpContextAccessor? _contextAccessor = null;
                //folderstructureEntity _folderStructure = new folderstructureEntity();

                //_folderStructure.userid = new Guid(userid);
                //_folderStructure.foldername = folderpath;
                //_folderStructure.physicalpath = $"{_ftpSettings.FtpAddress} {folderpath}";
                //_folderStructure.parentfolderid = null;
                //_folderStructure.isdeleted = false;

                //result = BFC.Core.FacadeCreatorObjects.General.folderstructureFCC.GetFacadeCreate(_contextAccessor)
                //        .Add(_folderStructure, cancellationToken).Result;
            }
            catch (Exception ex)
            {
                //MessageBox.Show();
            }
            return result;
        }

        #region Paging Method & Style 01
        private void BindGrid(int pageIndex)
        {
            dgvUsers.Rows.Clear();
            dgvUsers.Refresh();
            CancellationToken cancellationToken = new CancellationToken();
            IHttpContextAccessor httpContextAccessor = null;
            List<owin_userEntity> _users = new List<owin_userEntity>();
            _users = BFC.Core.FacadeCreatorObjects.Security.owin_userFCC.GetFacadeCreate(httpContextAccessor).GAPgListView(
                new BDO.Core.DataAccessObjects.SecurityModels.owin_userEntity()
                {
                    PageSize = this.PageSize,
                    CurrentPage = pageIndex,
                    SortExpression = "Masteruserid asc",
                },
                cancellationToken).Result.ToList();

            if (_users.Count > 0)
            {
                int recordCount = (int)_users.FirstOrDefault().RETURN_KEY;
                int Srno = 0;
                foreach (var user in _users)
                {
                    dgvUsers.Rows.Add(++Srno, user.userid, user.username, user.loweredusername, user.pkeyex, user.emailaddress);
                }

                this.PopulatePager(recordCount, pageIndex);
            }
        }
        private void PopulatePager(int recordCount, int currentPage)
        {
            List<PageEntity> pages = new List<PageEntity>();
            int startIndex, endIndex;
            int pagerSpan = 5;

            //Calculate the Start and End Index of pages to be displayed.
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
            endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
            if (currentPage > pagerSpan % 2)
            {
                if (currentPage == 2)
                {
                    endIndex = 5;
                }
                else
                {
                    endIndex = currentPage + 2;
                }
            }
            else
            {
                endIndex = (pagerSpan - currentPage) + 1;
            }

            if (endIndex - (pagerSpan - 1) > startIndex)
            {
                startIndex = endIndex - (pagerSpan - 1);
            }

            if (endIndex > pageCount)
            {
                endIndex = pageCount;
                startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
            }

            //Add the First Page Button.
            if (currentPage > 1)
            {
                pages.Add(new PageEntity { Text = "First", Value = "1" });
            }

            //Add the Previous Button.
            if (currentPage > 1)
            {
                pages.Add(new PageEntity { Text = "<<", Value = (currentPage - 1).ToString() });
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                pages.Add(new PageEntity { Text = i.ToString(), Value = i.ToString(), Selected = i == currentPage });
            }

            //Add the Next Button.
            if (currentPage < pageCount)
            {
                pages.Add(new PageEntity { Text = ">>", Value = (currentPage + 1).ToString() });
            }

            //Add the Last Button.
            if (currentPage != pageCount)
            {
                pages.Add(new PageEntity { Text = "Last", Value = pageCount.ToString() });
            }

            //Clear existing Pager Buttons.
            pnlPager.Controls.Clear();

            //Loop and add Buttons for Pager.
            int count = 1;
            int width = 60;
            int pointX = 10;
            foreach (PageEntity page in pages)
            {
                System.Windows.Forms.Button btnPage = new System.Windows.Forms.Button();
                //btnPage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                btnPage.Location = new Point(pointX, 15);
                btnPage.Name = page.Value;
                btnPage.Size = new Size(width, 38);
                btnPage.Text = page.Text;
                btnPage.Enabled = !page.Selected;
                btnPage.UseVisualStyleBackColor = true;
                btnPage.Click += new System.EventHandler(this.Page_Click);
                pnlPager.Controls.Add(btnPage);
                count++;
                pointX = pointX + width;
            }
        }
        private void Page_Click(object sender, EventArgs e)
        {
            Button btnPager = (sender as Button);
            this.BindGrid(int.Parse(btnPager.Name));
        }
        #endregion Paging Method & Style 01

        #region Paging Method & Style 02
        private void BindDataToGrid(int currentpage, int pageSize)
        {
            List<owin_userEntity> _users = _loadUserDataGrid(currentpage, pageSize);
            //dgvUsers.DataSource = _users;
            int Srno = 0;
            foreach (var user in _users)
            {
                dgvUsers.Rows.Add(++Srno, user.userid, user.username, user.loweredusername, user.pkeyex, user.emailaddress);
            }
        }
        private List<owin_userEntity> _loadUserDataGrid(int currentpage, int pageSize)
        {
            List<owin_userEntity> _users = new List<owin_userEntity>();
            try
            {

                dgvUsers.Rows.Clear();
                dgvUsers.Refresh();
                //btnImgGridEdit = new DataGridViewImageColumn();
                CancellationToken cancellationToken = new CancellationToken();
                IHttpContextAccessor httpContextAccessor = null;
                _users = BFC.Core.FacadeCreatorObjects.Security.owin_userFCC.GetFacadeCreate(httpContextAccessor).GAPgListView(
                    new BDO.Core.DataAccessObjects.SecurityModels.owin_userEntity()
                    {
                        PageSize = pageSize,
                        CurrentPage = currentpage,
                        SortExpression = "Masteruserid asc",
                    },
                    cancellationToken).Result.ToList();

                if (_users.Count > 0)
                {
                    int rowCount = (int)_users.FirstOrDefault().RETURN_KEY;
                    this.TotalPage = rowCount / PageSize;
                    if (rowCount % PageSize > 0) // if remainder is more than  zero 
                    {
                        this.TotalPage += 1;
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }

            return _users;
        }
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            this.CurrentPage = 1;
            BindDataToGrid(this.CurrentPage, this.PageSize);
        }
        private void btnLastPage_Click(object sender, EventArgs e)
        {
            this.CurrentPage = this.TotalPage;
            BindDataToGrid(this.CurrentPage, this.PageSize);
        }
        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (this.CurrentPage > 1)
            {
                this.CurrentPage--;
                BindDataToGrid(this.CurrentPage, this.PageSize);
            }
        }
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (this.CurrentPage < this.TotalPage)
            {
                this.CurrentPage++;
                BindDataToGrid(this.CurrentPage, this.PageSize);
            }
        }
        #endregion Paging Method & Style 02

        private void txtMilitaryNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                try
                {
                    MailAddress mailAddress = new MailAddress(email);
                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }
            }
            return false;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Invalid email address. Please enter a valid email.");
            }
        }
    }
}
