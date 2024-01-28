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
            panel1 = new Panel();
            label1 = new Label();
            lblUser = new Label();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            treeFolder = new TreeView();
            panel3 = new Panel();
            groupBox3 = new GroupBox();
            groupBox2 = new GroupBox();
            dgvFiles = new DataGridView();
            bgwFileWatcher = new System.ComponentModel.BackgroundWorker();
            folderBrowserDialog1 = new FolderBrowserDialog();
            label2 = new Label();
            txtDirectoryPath = new TextBox();
            btnBrowse = new Button();
            groupBox4 = new GroupBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFiles).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblUser);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1282, 76);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(141, 20);
            label1.Name = "label1";
            label1.Size = new Size(307, 35);
            label1.TabIndex = 1;
            label1.Text = "Rabiul Islam RoNy";
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
            panel2.Size = new Size(299, 597);
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
            treeFolder.Dock = DockStyle.Fill;
            treeFolder.Location = new Point(3, 23);
            treeFolder.Name = "treeFolder";
            treeFolder.Size = new Size(268, 553);
            treeFolder.TabIndex = 0;
            treeFolder.AfterSelect += treeFolder_AfterSelect;
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox4);
            panel3.Controls.Add(groupBox3);
            panel3.Controls.Add(groupBox2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(299, 76);
            panel3.Name = "panel3";
            panel3.Size = new Size(983, 597);
            panel3.TabIndex = 3;
            // 
            // groupBox3
            // 
            groupBox3.Location = new Point(19, 389);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(949, 190);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Upload File";
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
            // label2
            // 
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(6, 30);
            label2.Name = "label2";
            label2.Size = new Size(136, 35);
            label2.TabIndex = 2;
            label2.Text = "User Name: ";
            // 
            // txtDirectoryPath
            // 
            txtDirectoryPath.Location = new Point(140, 34);
            txtDirectoryPath.Name = "txtDirectoryPath";
            txtDirectoryPath.ReadOnly = true;
            txtDirectoryPath.Size = new Size(572, 27);
            txtDirectoryPath.TabIndex = 3;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(713, 33);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(94, 29);
            btnBrowse.TabIndex = 4;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
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
            // MainWindow
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1282, 673);
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
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFiles).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
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
        private Label label1;
        private System.ComponentModel.BackgroundWorker bgwFileWatcher;
        private FolderBrowserDialog folderBrowserDialog1;
        private GroupBox groupBox4;
        private Button btnBrowse;
        private TextBox txtDirectoryPath;
        private Label label2;
    }
}