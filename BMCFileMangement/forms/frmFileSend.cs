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
    public partial class frmFileSend : Form
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
            rootdirectorypath = _config.GetSection("UserDirectorySetting").GetSection("root").Value;
            myfolderid = _config.GetSection("UserDirectorySetting").GetSection("myfolderid").Value;
            InitializeComponent();
            LoadDirectoryByUser();
            _LoadUser();
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
                        CurrentPage = 1
                    },
                    cancellationToken).Result;

                if (_users != null && _users.Count > 0)
                {
                    cboUser.DataSource = _users;
                    cboUser.ValueMember = "strValue1";
                    cboUser.DisplayMember = "Text";
                }
            }
            catch (Exception ex)
            { throw ex; }
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
            // Let Shared Folder is C:\MyFolderss
            // string desPath = @"C:\MyFolder";

            // Display a confirmation message box
            DialogResult result = MessageBox.Show("Are you sure you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {

                var desPath = rootdirectorypath;

                if (!Directory.Exists(desPath)) Directory.CreateDirectory(desPath);

                string sourcepath = txtFilePath.Text.Trim();
                string fileName = Path.GetFileName(sourcepath);
                desPath = Path.Combine(desPath, fileName);

                if (File.Exists(desPath)) File.Delete(desPath);
                bool isCopy = false;
                try
                {
                    File.Copy(sourcepath, desPath, true);
                    isCopy = true;
                }
                catch { }

                if (isCopy)
                {
                    CancellationToken cancellationToken = new CancellationToken();
                    IHttpContextAccessor httpContextAccessor = null;
                    // Save File
                    var _file = BFC.Core.FacadeCreatorObjects.General.filestructureFCC.GetFacadeCreate(httpContextAccessor).Add(
                        new BDO.Core.DataAccessObjects.Models.filestructureEntity
                        {
                            folderid = long.Parse(myfolderid),//_userprofile.CurrentUser.folderid,
                            filename = fileName,
                            userfilename = fileName,
                            filepath = desPath,
                            isdeleted = false

                        }, cancellationToken); ;
                    string ddd = cboUser.GetItemText(cboUser.SelectedItem);
                    var _filetrans = BFC.Core.FacadeCreatorObjects.General.filetransferinfoFCC.GetFacadeCreate(httpContextAccessor).Add(
                            new BDO.Core.DataAccessObjects.Models.filetransferinfoEntity()
                            {
                                folderid = long.Parse(myfolderid),//_userprofile.CurrentUser.folderid,
                                fileid = _file != null && _file.Result > 0 ? _file.Result : null,
                                fromusername = _userprofile.CurrentUser.username,
                                fromuserid = _userprofile.CurrentUser.userid,
                                tousername = cboUser.GetItemText(cboUser.SelectedItem),
                                touserid = new Guid(cboUser.SelectedValue.ToString()),
                                sentdate = DateTime.Now,
                                filename = Path.GetFileName(desPath),
                                fileversion = null,
                                fullpath = desPath,
                                priority = 1,
                                filejsondata = "",
                                status = 1,
                                expecteddate = DateTime.Now
                            },
                            cancellationToken);

                    if (_filetrans.Result > 0)
                    {
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

        private DataTable loadFileNames(string folderpath)
        {
            String[] files = Directory.GetFiles(folderpath);
            DataTable table = new DataTable();
            table.Columns.Add("File Name");
            table.Columns.Add("Length");
            table.Columns.Add("Last Access Time");
            table.Columns.Add("Last Write Time");

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = new FileInfo(files[i]);
                DataRow dr = table.NewRow();
                dr[0] = file.Name;
                dr[1] = FileSizeFormatter.FormatSize(file.Length);  //file.Length;
                dr[2] = file.LastAccessTime;
                dr[3] = file.LastWriteTime;
                table.Rows.Add(dr);
            }
            return table;
        }
        public static class FileSizeFormatter
        {
            // Load all suffixes in an array
            static readonly string[] suffixes =
            { "Bytes", "KB", "MB", "GB", "TB", "PB" };
            public static string FormatSize(Int64 bytes)
            {
                int counter = 0;
                decimal number = (decimal)bytes;
                while (Math.Round(number / 1024) >= 1)
                {
                    number = number / 1024;
                    counter++;
                }
                return string.Format("{0:n1}{1}", number, suffixes[counter]);
            }
        }
        public void LoadDirectoryByUser()
        {
            string Dir = rootdirectorypath;


            if (Directory.Exists(Dir))
            {
                var userid = _userprofile.CurrentUser.userid;

                string _userDirectory = Path.Combine(Dir, userid.ToString());
                if (!Directory.Exists(_userDirectory)) { Directory.CreateDirectory(_userDirectory); }

                DirectoryInfo di = new DirectoryInfo(_userDirectory);
                TreeNode tds = treeFolder.Nodes.Add(di.Name);
                tds.Tag = di.FullName;
                tds.StateImageIndex = 0;
                //LoadFiles(Dir, tds);
                LoadSubDirectories(_userDirectory, tds);
            }
            else
            {
                MessageBox.Show("directory not found");
            }




        }
        private void LoadSubDirectories(string dir, TreeNode td)
        {
            // Get all subdirectories
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            // Loop through them to see if they have any other subdirectories
            foreach (string subdirectory in subdirectoryEntries)
            {
                DirectoryInfo di = new DirectoryInfo(subdirectory);
                TreeNode tds = td.Nodes.Add(di.Name);
                tds.StateImageIndex = 0;
                tds.Tag = di.FullName;
                //LoadFiles(subdirectory, tds);
                LoadSubDirectories(subdirectory, tds);
                //UpdateProgress();
            }
        }
        public TreeNode previousSelectedNode = null;
        private void treeFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;

            if (treeFolder.SelectedNode != null)
            {
                treeFolder.SelectedNode.BackColor = Color.Green;
                treeFolder.SelectedNode.ForeColor = Color.White;

                if (previousSelectedNode != null)
                {
                    previousSelectedNode.BackColor = Color.Gainsboro;
                    previousSelectedNode.ForeColor = SystemColors.WindowText;
                }
            }
            previousSelectedNode = treeFolder.SelectedNode;
            string di = treeFolder.SelectedNode.Tag as string;
            //dgvFiles.DataSource = new System.IO.DirectoryInfo(di).GetFiles();
            dgvFiles.DataSource = loadFileNames(di);

            for (int i = 0; i < dgvFiles.Columns.Count - 1; i++)
            {
                dgvFiles.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgvFiles.Columns[dgvFiles.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
