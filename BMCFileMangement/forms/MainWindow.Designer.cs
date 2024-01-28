using BMCFileMangement.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Windows.Services.Maps;

namespace BMCFileMangement.forms
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();


            notificationAndDataQuerybgWorker1 = new UserControls.NotificationAndDataQueryBGWorker(_config,
            _loggerFactory,
            _msgService,
            _applog,
            _userprofile,
            _fileNotificationList,
            this);

            lblUserName = new Label();
            lblUser = new Label();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            treeFolder = new TreeView();
            panel3 = new Panel();
            statusStrip1 = new StatusStrip();
            currentDateTimeStip = new ToolStripStatusLabel();
            CurrentUserNameStip = new ToolStripStatusLabel();
            groupBox4 = new GroupBox();
            btnBrowse = new Button();
            txtDirectoryPath = new TextBox();
            label2 = new Label();
            groupBox3 = new GroupBox();
            cboUser = new ComboBox();
            btnSave = new Button();
            label4 = new Label();
            btnBrowseFile = new Button();
            label3 = new Label();
            txtFilePath = new TextBox();
            groupBox2 = new GroupBox();
            dgvFiles = new DataGridView();
            bgwFileWatcher = new System.ComponentModel.BackgroundWorker();
            folderBrowserDialog1 = new FolderBrowserDialog();
            tmDateTime = new System.Windows.Forms.Timer(components);
            openFileDialog1 = new OpenFileDialog();


            cboUser = new ComboBox();

            notificationDataListViewControl1 = new UserControls.NotificationDataListViewControl(_config,
            _loggerFactory,
            _msgService,
            _applog,
            _userprofile,
            _fileNotificationList);

            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            statusStrip1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFiles).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblUserName);
            panel1.Controls.Add(lblUser);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1282, 76);
            panel1.TabIndex = 1;
            // 
            // lblUserName
            // 
            lblUserName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblUserName.Location = new Point(141, 20);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(307, 35);
            lblUserName.TabIndex = 1;
            // 
            // lblUser
            // 
            lblUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblUser.Location = new Point(12, 20);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(136, 35);
            lblUser.TabIndex = 0;
            lblUser.Text = "User Name: ";
            // 
            // panel2
            // 
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 76);
            panel2.Name = "panel2";
            panel2.Size = new Size(299, 958);
            panel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(treeFolder);
            groupBox1.Location = new Point(12, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(274, 579);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Directory List";
            // 
            // treeFolder
            // 
            treeFolder.BackColor = Color.Gainsboro;
            treeFolder.Dock = DockStyle.Fill;
            treeFolder.Location = new Point(3, 23);
            treeFolder.Name = "treeFolder";
            treeFolder.Size = new Size(268, 553);
            treeFolder.TabIndex = 0;
            treeFolder.AfterSelect += treeFolder_AfterSelect;
            treeFolder.Validating += treeFolder_Validating;
            // 
            // panel3
            // 
            panel3.Controls.Add(statusStrip1);
            panel3.Controls.Add(groupBox4);
            panel3.Controls.Add(groupBox3);
            panel3.Controls.Add(groupBox2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(299, 76);
            panel3.Name = "panel3";
            panel3.Size = new Size(983, 958);
            panel3.TabIndex = 3;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { currentDateTimeStip, CurrentUserNameStip });
            statusStrip1.Location = new Point(0, 932);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(983, 26);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // currentDateTimeStip
            // 
            currentDateTimeStip.Name = "currentDateTimeStip";
            currentDateTimeStip.Size = new Size(75, 20);
            currentDateTimeStip.Text = "_datetime";
            // 
            // CurrentUserNameStip
            // 
            CurrentUserNameStip.Name = "CurrentUserNameStip";
            CurrentUserNameStip.Size = new Size(73, 20);
            CurrentUserNameStip.Text = "username";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnBrowse);
            groupBox4.Controls.Add(txtDirectoryPath);
            groupBox4.Controls.Add(label2);
            groupBox4.Location = new Point(16, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(952, 79);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Browse Directory";
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(713, 32);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(94, 31);
            btnBrowse.TabIndex = 4;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtDirectoryPath
            // 
            txtDirectoryPath.Location = new Point(140, 34);
            txtDirectoryPath.Multiline = true;
            txtDirectoryPath.Name = "txtDirectoryPath";
            txtDirectoryPath.ReadOnly = true;
            txtDirectoryPath.Size = new Size(572, 28);
            txtDirectoryPath.TabIndex = 3;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(6, 36);
            label2.Name = "label2";
            label2.Size = new Size(136, 35);
            label2.TabIndex = 2;
            label2.Text = "Select Folder: ";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cboUser);
            groupBox3.Controls.Add(btnSave);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(btnBrowseFile);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(txtFilePath);
            groupBox3.Location = new Point(16, 388);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(949, 190);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Upload File";
            // 
            // cboUser
            // 
            cboUser.FormattingEnabled = true;
            cboUser.Location = new Point(140, 81);
            cboUser.Name = "cboUser";
            cboUser.Size = new Size(572, 28);
            cboUser.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(41, 128, 185);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(692, 148);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(251, 36);
            btnSave.TabIndex = 10;
            btnSave.Text = "Send Notification";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(3, 77);
            label4.Name = "label4";
            label4.Size = new Size(136, 35);
            label4.TabIndex = 8;
            label4.Text = "Select User";
            // 
            // btnBrowseFile
            // 
            btnBrowseFile.Location = new Point(713, 32);
            btnBrowseFile.Name = "btnBrowseFile";
            btnBrowseFile.Size = new Size(94, 31);
            btnBrowseFile.TabIndex = 7;
            btnBrowseFile.Text = "Browse...";
            btnBrowseFile.UseVisualStyleBackColor = true;
            btnBrowseFile.Click += btnBrowseFile_Click;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(3, 32);
            label3.Name = "label3";
            label3.Size = new Size(136, 35);
            label3.TabIndex = 5;
            label3.Text = "Select File: ";
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(140, 34);
            txtFilePath.Multiline = true;
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new Size(572, 28);
            txtFilePath.TabIndex = 6;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvFiles);
            groupBox2.Location = new Point(16, 91);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(955, 291);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "File Lists";
            // 
            // dgvFiles
            // 
            dgvFiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFiles.Dock = DockStyle.Fill;
            dgvFiles.Location = new Point(3, 23);
            dgvFiles.Name = "dgvFiles";
            dgvFiles.RowHeadersWidth = 51;
            dgvFiles.Size = new Size(949, 265);
            dgvFiles.TabIndex = 0;
            // 
            // tmDateTime
            // 
            tmDateTime.Enabled = true;
            tmDateTime.Interval = 1000;
            tmDateTime.Tick += timer1_Tick;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainWindow
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1282, 1034);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BMC File Management";
            Load += MainWindow_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFiles).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnCloseApp;
        private Panel panel2;
        private Panel panel3;
        private GroupBox groupBox1;
        private TreeView treeFolder;
        private GroupBox groupBox2;
        private DataGridView dgvFiles;
        private GroupBox groupBox3;
        private Label lblUser;
        private Label lblUserName;
        private System.ComponentModel.BackgroundWorker bgwFileWatcher;
        private FolderBrowserDialog folderBrowserDialog1;
        private GroupBox groupBox4;
        private Button btnBrowse;
        private TextBox txtDirectoryPath;
        private Label label2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel currentDateTimeStip;
        private System.Windows.Forms.Timer tmDateTime;
        private ToolStripStatusLabel CurrentUserNameStip;
        private Button btnBrowseFile;
        private Label label3;
        private TextBox txtFilePath;
        private Label label4;
        private OpenFileDialog openFileDialog1;
        private Button btnSave;
        private UserControls.NotificationAndDataQueryBGWorker notificationAndDataQuerybgWorker1;
        private UserControls.NotificationDataListViewControl notificationDataListViewControl1;
        private ComboBox cboUser;
    }
}