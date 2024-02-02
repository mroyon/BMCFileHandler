using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using BMCFileMangement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMCFileMangement.forms
{
    public partial class frmOutBox : Form
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


        private int PageSize = 10;
        private int CurrentPage = 1;
        private int TotalPage = 0;




        public frmOutBox(IConfigurationRoot config,
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

            dtGrdInBox.Columns.Add("SentDate", "Sent Date");
            dtGrdInBox.Columns.Add("ReceivedDate", "Received Date");
            dtGrdInBox.Columns.Add("OpenDate", "Open Date");
            dtGrdInBox.Columns.Add("Status", "Status");

            dtGrdInBox.Columns["fromusername"].DataPropertyName = "fromusername";
            dtGrdInBox.Columns["sentdate"].DataPropertyName = "sentdate";
            dtGrdInBox.Columns["filename"].DataPropertyName = "filename";
            dtGrdInBox.Columns["priority"].DataPropertyName = "priority";
            dtGrdInBox.Columns["fromuserremark"].DataPropertyName = "fromuserremark";


            dtGrdInBox.Columns["SentDate"].DataPropertyName = "SentDate";
            dtGrdInBox.Columns["ReceivedDate"].DataPropertyName = "ReceivedDate";
            dtGrdInBox.Columns["OpenDate"].DataPropertyName = "OpenDate";
            dtGrdInBox.Columns["Status"].DataPropertyName = "Status";

            dtGrdInBox.AutoResizeColumns();

            // Configure the details DataGridView so that its columns automatically
            // adjust their widths when the data changes.
            dtGrdInBox.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            BindDataToGrid(1, 10);
        }

        public void LoadTransFiles()
        {

            string Dir = rootdirectorypath;
        }


        #region Paging Method & Style 02
        private void BindDataToGrid(int currentpage, int pageSize)
        {
            List<filetransferinfoEntity> _users = _loadUserDataGrid(currentpage, pageSize);
            //dtGrdInBox.DataSource = _users;
            int Srno = 0;
            foreach (var user in _users)
            {
                dtGrdInBox.Rows.Add(user.fromusername, user.sentdate, user.filename, user.fromuserremark, user.showedpopup);
            }
        }
        private List<filetransferinfoEntity> _loadUserDataGrid(int currentpage, int pageSize)
        {
            List<filetransferinfoEntity> _users = new List<filetransferinfoEntity>();
            try
            {
                dtGrdInBox.Rows.Clear();
                dtGrdInBox.Refresh();
                //btnImgGridEdit = new DataGridViewImageColumn();
                CancellationToken cancellationToken = new CancellationToken();

                filetransferinfoEntity objEntity = new filetransferinfoEntity();
                objEntity.PageSize = pageSize;
                objEntity.CurrentPage = currentpage;
                objEntity.SortExpression = "ReceivedDate desc";
                objEntity.fromuserid = _userprofile.CurrentUser.userid;

                if (txtContent.Text != "")
                    objEntity.strCommonSerachParam = txtContent.Text;


                IHttpContextAccessor httpContextAccessor = null;
                _users = BFC.Core.FacadeCreatorObjects.General.filetransferinfoFCC.GetFacadeCreate(httpContextAccessor).GetAllByPagesInBoxView(objEntity,cancellationToken).Result.ToList();

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

        private void dtGrdInBox_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.RowIndex >= 0 && e.ColumnIndex == dtGrdInBox.Columns["filename"].Index)
                {
                    string fileName = dtGrdInBox.Rows[e.RowIndex].Cells["filename"].Value.ToString(); // Replace with the actual column name containing file information
                    DownloadFile(fileName);
                }
        }

        private async Task DownloadFile(string fileName)
        {
            string fullPath = _userprofile.CurrentUser.userid.GetValueOrDefault().ToString() + "/IN/" + fileName;
            var fileStream = await _fTPTransferService.DownloadFile(fullPath);

            // Using statement ensures that the FileStream is properly closed and resources are released
            using (FileStream outputStream = new FileStream(fileName, FileMode.Create))
            {
                // Read from the input stream and write to the file stream
                fileStream.CopyTo(outputStream);
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = fileName,
                UseShellExecute = true
            });

            //MessageBox.Show($"Downloading file: {fileName}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindDataToGrid(1, 10);
        }
    }
}
