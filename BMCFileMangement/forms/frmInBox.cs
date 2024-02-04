using BDO.Core.DataAccessObjects.ExtendedEntities;
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
using System.Threading;
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
        private readonly IFTPTransferService _fTPTransferService;


        private int PageSize = 10;
        private int CurrentPage = 1;
        private int TotalPage = 0;


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
            _userprofile = userprofile;

            _fileNotificationList = fileNotificationList;
            _fTPTransferService = fTPTransferService;


            InitializeComponent();
            InitializeComponent2();
        }


        public void InitializeComponent2()
        {
            btnSearchInboxData.Click += BtnReloadInboxData_Click;
            btnClearSearchInboxData.Click += BtnClearSearchInboxData_Click;
            dtGrdInBox.AutoGenerateColumns = false;


            dtGrdInBox.Columns.Add("filetransid", "File Transfer ID");

            dtGrdInBox.Columns.Add("fromusername", "From User");
            //dtGrdInBox.Columns.Add("sentdate", "Sent Date");
            dtGrdInBox.Columns.Add("filename", "File Name");
            dtGrdInBox.Columns.Add("priority", "Priority");

            dtGrdInBox.Columns.Add("SentDate", "Sent Date");
            dtGrdInBox.Columns.Add("ReceivedDate", "Received Date");
            dtGrdInBox.Columns.Add("OpenDate", "Open Date");
            dtGrdInBox.Columns.Add("Status", "Status");
            dtGrdInBox.Columns.Add("fromuserremark", "Remarks");


            dtGrdInBox.Columns["filetransid"].DataPropertyName = "filetransid";

            dtGrdInBox.Columns["fromusername"].DataPropertyName = "fromusername";
            dtGrdInBox.Columns["filename"].DataPropertyName = "filename";
            dtGrdInBox.Columns["priority"].DataPropertyName = "priority";

            dtGrdInBox.Columns["SentDate"].DataPropertyName = "SentDate";
            dtGrdInBox.Columns["ReceivedDate"].DataPropertyName = "ReceivedDate";
            dtGrdInBox.Columns["OpenDate"].DataPropertyName = "OpenDate";
            dtGrdInBox.Columns["Status"].DataPropertyName = "Status";
            dtGrdInBox.Columns["fromuserremark"].DataPropertyName = "fromuserremark";

            dtGrdInBox.AutoResizeColumns();

            // Configure the details DataGridView so that its columns automatically
            // adjust their widths when the data changes.
            dtGrdInBox.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            BindDataToGrid(1, 10);
        }

        private void BtnClearSearchInboxData_Click(object? sender, EventArgs e)
        {
            txtContent.Text = String.Empty;
            BindDataToGrid(1, 10);
        }

        private void BtnReloadInboxData_Click(object? sender, EventArgs e)
        {
            BindDataToGrid(1, 10);
        }


        #region Paging Method & Style 02
        private void BindDataToGrid(int currentpage, int pageSize)
        {
            List<filetransferinfoEntity> _files_inbox = _loadUserDataGrid(currentpage, pageSize);
            //dtGrdInBox.DataSource = _users;
            int Srno = 0;
            foreach (var _file_inbox in _files_inbox)
            {
                dtGrdInBox.Rows.Add(_file_inbox.fromusername,
                    //_file_inbox.sentdate,
                    _file_inbox.filename,
                    _file_inbox.priority,
                    
                    _file_inbox.sentdate,
                    _file_inbox.receiveddate,
                    _file_inbox.opendate,
                    _file_inbox.status,
                    //_file_inbox.showedpopup,
                    _file_inbox.fromuserremark);

                    for (int i = 0; i < dtGrdInBox.Columns.Count - 1; i++)
                    {
                        dtGrdInBox.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    dtGrdInBox.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtGrdInBox.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dtGrdInBox.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (_files_inbox.Count == 0)
            {
                for (int i = 0; i < dtGrdInBox.Columns.Count - 1; i++)
                {
                    dtGrdInBox.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        private List<filetransferinfoEntity> _loadUserDataGrid(int currentpage, int pageSize)
        {
            List<filetransferinfoEntity> _files_inbox = new List<filetransferinfoEntity>();
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
                objEntity.touserid = _userprofile.CurrentUser.userid;

                if (txtContent.Text != "")
                    objEntity.strCommonSerachParam = txtContent.Text;


                IHttpContextAccessor httpContextAccessor = null;
                _files_inbox = BFC.Core.FacadeCreatorObjects.General.filetransferinfoFCC.
                    GetFacadeCreate(httpContextAccessor).GetAllByPagesInBoxView(objEntity, cancellationToken).Result.ToList();

                if (_files_inbox.Count > 0)
                {
                    int rowCount = (int)_files_inbox.FirstOrDefault().RETURN_KEY;
                    this.TotalPage = rowCount / PageSize;
                    if (rowCount % PageSize > 0) // if remainder is more than  zero 
                    {
                        this.TotalPage += 1;
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }

            return _files_inbox;
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
                string filetransid = dtGrdInBox.Rows[e.RowIndex].Cells["filetransid"].Value.ToString(); // Replace with the actual column name containing file information
                DialogResult result = MessageBox.Show("Are you sure you want to proceed to download this file?", "Download Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DateTime dt = DateTime.Now;
                    DownloadFile(fileName);

                    CancellationToken cancellationToken = new CancellationToken();
                    IHttpContextAccessor httpContextAccessor = null;
                    filetransferinfoEntity objFileInBox = new filetransferinfoEntity()
                    {
                        filetransid = long.Parse(filetransid),
                        isopen = true,
                        opendate = dt,
                        status = 2
                    };

                    objFileInBox.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                    objFileInBox.BaseSecurityParam = _fTPTransferService.GetSecurityCapsule(dt);
                    var _filetrans = BFC.Core.FacadeCreatorObjects.General.filetransferinfoFCC.
                        GetFacadeCreate(httpContextAccessor).UpdateOpenData(objFileInBox, cancellationToken);
                }
            }
        }

        private async Task DownloadFile(string fileName)
        {
            string fullPath = _userprofile.CurrentUser.userid.GetValueOrDefault().ToString() + "/INBOX/" + fileName;
            var fileStream = await _fTPTransferService.DownloadFile_FileStream(fullPath);

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


    }
}
