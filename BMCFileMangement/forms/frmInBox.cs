using BDO.Core.DataAccessObjects.CommonEntities;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using BMCFileMangement.Services.DisServices;
using BMCFileMangement.Services.Interface;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        private readonly IFTPTransferService _fTPTransferService;

        private readonly IOptions<FtpSettingsOptions> _ftpOptions;

        private int _PageSize = 500;
        private int CurrentPage = 1;
        private int TotalPage = 0;

        /// <summary>
        /// frmInBox
        /// </summary>
        /// <param name="config"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="msgService"></param>
        /// <param name="applog"></param>
        /// <param name="userprofile"></param>
        /// <param name="fTPTransferService"></param>
        public frmInBox(IConfigurationRoot config,
            ILoggerFactory loggerFactory,
            IMessageService msgService,
            IApplicationLogService applog,
            IUserProfileService userprofile,
            IFTPTransferService fTPTransferService)
        {
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<frmMainWindow>();
            _msgService = msgService;
            _applog = applog;
            _userprofile = userprofile;

            _fTPTransferService = fTPTransferService;


            InitializeComponent();
            InitializeComponent2();
            //tinyMceEditor.CreateEditor();
        }


        public void InitializeComponent2()
        {
            btnSearchInboxData.Click += BtnReloadInboxData_Click;
            btnClearSearchInboxData.Click += BtnClearSearchInboxData_Click;
            //dtGrdInBox.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dtGrdInBox.EnableHeadersVisualStyles = false;
            BindDataToGrid(1);
        }

        private void BtnClearSearchInboxData_Click(object? sender, EventArgs e)
        {
            txtContent.Text = String.Empty;
            BindDataToGrid(1);
        }

        private void BtnReloadInboxData_Click(object? sender, EventArgs e)
        {
            BindDataToGrid(1);
        }


        #region Paging Method & Style 02
        private void BindDataToGrid(int currentpage)
        {
            List<filetransferinfoEntity> _files_inbox = _loadUserDataGrid(currentpage);
            //dtGrdInBox.DataSource = _users;
            int Srno = 0;
            foreach (var _file_inbox in _files_inbox)
            {

                dtGrdInBox.Rows.Add(
                    _file_inbox.filetransid,
                    _file_inbox.fromusername,
                    _file_inbox.filename,
                    (_file_inbox.priority == 1 ? "High" : (_file_inbox.priority == 2 ? "Medium" : "Low")),
                    _file_inbox.sentdate,
                    _file_inbox.isreceived,
                    _file_inbox.receiveddate,
                    _file_inbox.showedpopup,
                    _file_inbox.showeddate,
                    _file_inbox.isopen,
                    _file_inbox.opendate,
                    _file_inbox.status,
                    _file_inbox.fromuserremark);
            }
            if (_files_inbox.Count == 0)
            {
                for (int i = 0; i < dtGrdInBox.Columns.Count - 1; i++)
                {
                    dtGrdInBox.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        private List<filetransferinfoEntity> _loadUserDataGrid(int currentpage)
        {
            List<filetransferinfoEntity> _files_inbox = new List<filetransferinfoEntity>();
            try
            {
                dtGrdInBox.Rows.Clear();
                dtGrdInBox.Refresh();
                //btnImgGridEdit = new DataGridViewImageColumn();
                CancellationToken cancellationToken = new CancellationToken();

                filetransferinfoEntity objEntity = new filetransferinfoEntity();
                objEntity.PageSize = _PageSize;
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
                    this.TotalPage = rowCount / _PageSize;
                    if (rowCount % _PageSize > 0) // if remainder is more than  zero 
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
            BindDataToGrid(this.CurrentPage);
        }
        private void btnLastPage_Click(object sender, EventArgs e)
        {
            this.CurrentPage = this.TotalPage;
            BindDataToGrid(this.CurrentPage);
        }
        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (this.CurrentPage > 1)
            {
                this.CurrentPage--;
                BindDataToGrid(this.CurrentPage);
            }
        }
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (this.CurrentPage < this.TotalPage)
            {
                this.CurrentPage++;
                BindDataToGrid(this.CurrentPage);
            }
        }

        //private Form GetFrmMainWindow()
        //{
        //    IOptions<FtpSettingsOptions> ftpOptions = new IOptions<FtpSettingsOptions>();
        //    return frmMainWindow(_config,
        //        _loggerFactory,
        //    _msgService,
        //    _applog,
        //        _userprofile,
        //        _fileNotificationList,
        //        _fTPTransferService, ftpOptions);
        //}
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

                    clsSecurityCapsule objCap = new clsSecurityCapsule();

                    objFileInBox.BaseSecurityParam = new BDO.Core.Base.SecurityCapsule();
                    objFileInBox.BaseSecurityParam = objCap.GetSecurityCapsule(dt, _userprofile.CurrentUser.username);
                    objCap.Dispose();
                    var _filetrans = BFC.Core.FacadeCreatorObjects.General.filetransferinfoFCC.
                        GetFacadeCreate(httpContextAccessor).UpdateOpenData(objFileInBox, cancellationToken);

                    BindDataToGrid(this.CurrentPage);
                }
            }

            if (e.RowIndex >= 0 && e.ColumnIndex == dtGrdInBox.Columns["fromusername"].Index)
            {
                filetransferinfoEntity _filetransferinfo = new filetransferinfoEntity();
                string filetransid = dtGrdInBox.Rows[e.RowIndex].Cells["filetransid"].Value.ToString();
                _filetransferinfo.filetransid = !string.IsNullOrEmpty(filetransid) ? long.Parse(filetransid) : -99;
                //this.IsMdiContainer = true;
                var _frmFileSendEdit = new frmFileSendEdit(
                                                            _filetransferinfo,
                                                            _config,
                                                            _loggerFactory,
                                                            _msgService,
                                                            _applog,
                                                            _userprofile,
                                                            _fTPTransferService
                                                          );
                _frmFileSendEdit.ShowDialog();
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

        private void dtGrdInBox_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridViewRow row = dtGrdInBox.Rows[e.RowIndex];
                    bool isOpen = Convert.ToBoolean(row.Cells["isopen"].Value);
                    bool isShowedpopup = Convert.ToBoolean(row.Cells["showedpopup"].Value);
                    bool isReceived = Convert.ToBoolean(row.Cells["isreceived"].Value);

                    if (isOpen)
                    {
                        row.Cells["isopen"].Style.BackColor = Color.LightBlue;
                    }
                    else if (isShowedpopup && !isOpen)
                    {
                        row.Cells["showedpopup"].Style.BackColor = Color.Yellow;
                    }
                    else if (isReceived && !isShowedpopup && !isOpen)
                    {
                        row.Cells["isreceived"].Style.BackColor = Color.LightGreen;
                    }
                }
            }
            catch { }
        }

        private void frmInBox_Load(object sender, EventArgs e)
        {

        }
    }
}
