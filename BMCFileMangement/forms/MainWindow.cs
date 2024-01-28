using BMCFileMangement.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BMCFileMangement.forms
{
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : Form
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<MainWindow> _logger;
        private readonly IMessageService _msgService;
        private readonly IConfigurationRoot _config;
        private readonly IApplicationLogService _applog;
        private readonly IUserProfileService _userprofile;

        private BackgroundWorker backgroundWorker;

        /// <summary>
        /// MainWindow
        /// </summary>
        /// <param name="config"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="msgService"></param>
        /// <param name="applog"></param>
        /// <param name="userprofile"></param>
        public MainWindow(
            IConfigurationRoot config,
            ILoggerFactory loggerFactory,
            IMessageService msgService,
            IApplicationLogService applog,
            IUserProfileService userprofile)
        {

            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<MainWindow>();
            _msgService = msgService;
            _applog = applog;

            InitializeComponent();

            _userprofile = userprofile;

            CurrentUserNameStip.Text = _userprofile.CurrentUser.username;
            lblUserName.Text = _userprofile.CurrentUser.username;
            InitializeBackgroundWorker();
        }

        /// <summary>
        /// InitializeBackgroundWorker
        /// </summary>
        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            backgroundWorker.DoWork += async (sender, e) => await BackgroundWorker_DoWork();
            backgroundWorker.ProgressChanged += async (sender, e) => await BackgroundWorker_ProgressChanged(sender, e);
            backgroundWorker.RunWorkerCompleted += async (sender, e) => await BackgroundWorker_RunWorkerCompleted(sender, e);

            // Start the background worker when the main form loads
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// BackgroundWorker_DoWork
        /// </summary>
        /// <returns></returns>
        private async Task BackgroundWorker_DoWork()
        {
            // Infinite loop to keep the background worker running
            while (!backgroundWorker.CancellationPending)
            {
                // Your asynchronous background work goes here
                // For example, perform an asynchronous task

                //MessageBox.Show("Asdf");
                await watchFolderContents();
                // Simulate an asynchronous task with Task.Delay
                await Task.Delay(2000); // Adjust as needed

                // Report progress (if needed)
                //backgroundWorker.ReportProgress(0);
            }
        }

        /// <summary>
        /// watchFolderContents
        /// </summary>
        /// <returns></returns>
        private async Task watchFolderContents()
        {
            string folderPath = @"C:\TestFolderBMC";

            var heroImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", @"Money-Heist.jpg");
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 100)
                .AddText("Folder Changed")
                .AddInlineImage(new Uri(heroImage))
                .AddButton(new ToastButton()
                            .SetContent("Open Folder")
                            .AddArgument("url", folderPath))
                //.AddAttributionText("Cool code")
                .SetToastScenario(ToastScenario.Default)
                .Show(toast =>
                {
                    toast.ExpirationTime = DateTime.Now.AddSeconds(15);
                });

            await Task.Delay(20000);
        }

        /// <summary>
        /// MainWindow_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            lblUserName.Text = _userprofile.CurrentUser.username;
        }

        // <summary>
        /// BackgroundWorker_ProgressChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async Task BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This method is called on the main thread when progress is reported
            // Update UI or perform any necessary actions based on the background work
        }

        /// <summary>
        /// BackgroundWorker_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async Task BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Cleanup or handle completion if needed
        }
        

        // Override the form's OnFormClosing event to safely cancel the background worker
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Ensure the background worker is stopped when the form is closing
            if (backgroundWorker != null && backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtDirectoryPath.Text;
            DialogResult drResult = folderBrowserDialog1.ShowDialog();
            if (drResult == System.Windows.Forms.DialogResult.OK)
            {
                txtDirectoryPath.Text = folderBrowserDialog1.SelectedPath;

                if (txtDirectoryPath.Text != "" && Directory.Exists(txtDirectoryPath.Text))
                    LoadDirectory(txtDirectoryPath.Text);
            }
        }

        //private void btnLoadDirectory_Click(object sender, EventArgs e)
        //{
        //    if (txtDirectoryPath.Text != "" && Directory.Exists(txtDirectoryPath.Text))
        //        LoadDirectory(txtDirectoryPath.Text);
        //}

        public void LoadDirectory(string Dir)
        {
            DirectoryInfo di = new DirectoryInfo(Dir);
            //Setting ProgressBar Maximum Value
            //progressBar1.Maximum = Directory.GetFiles(Dir, "*.*", SearchOption.AllDirectories).Length + Directory.GetDirectories(Dir, "**", SearchOption.AllDirectories).Length;
            TreeNode tds = treeFolder.Nodes.Add(di.Name);
            tds.Tag = di.FullName;
            tds.StateImageIndex = 0;
            //LoadFiles(Dir, tds);
            LoadSubDirectories(Dir, tds);
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
        private void treeFolder_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (treeFolder.SelectedNode != null)
            //{
            //    //treeFolder.SelectedNode.BackColor = Color.Gainsboro;
            //    //treeFolder.SelectedNode.ForeColor = SystemColors.WindowText;
            //    previousSelectedNode = treeFolder.SelectedNode;
            //}
        }
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

            //for (int i = 0; i < dgvFiles.Columns.Count; i++)
            //{
            //    int colw = dgvFiles.Columns[i].Width;
            //    dgvFiles.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //    dgvFiles.Columns[i].Width = colw;
            //}


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

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentDateTimeStip.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Let Shared Folder is C:\MyFolderss
            string desPath = @"C:\MyFolder";
            if (!Directory.Exists(desPath)) Directory.CreateDirectory(desPath);

            string sourcepath = txtFilePath.Text.Trim();
            string fileName = Path.GetFileName(sourcepath);
            desPath = Path.Combine(desPath, fileName);
            
            if (File.Exists(desPath)) File.Delete(desPath);

            try
            {
                File.Copy(sourcepath, desPath, true);
            }
            catch { }
        }
    }
}
