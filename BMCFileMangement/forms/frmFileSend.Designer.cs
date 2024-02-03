namespace BMCFileMangement.forms
{
    partial class frmFileSend
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
            groupBox1 = new GroupBox();
            treeFolder = new TreeView();
            groupBox2 = new GroupBox();
            dgvFiles = new DataGridView();
            panel1 = new Panel();
            panel2 = new Panel();
            groupBox3 = new GroupBox();
            txtRemarks = new TextBox();
            label1 = new Label();
            btnSendFile = new Button();
            cboUser = new ComboBox();
            label4 = new Label();
            btnBrowseFile = new Button();
            label3 = new Label();
            txtFilePath = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFiles).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(treeFolder);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(242, 392);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "My Directory";
            // 
            // treeFolder
            // 
            treeFolder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            treeFolder.BackColor = Color.PowderBlue;
            treeFolder.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            treeFolder.Location = new Point(7, 37);
            treeFolder.Margin = new Padding(3, 4, 3, 4);
            treeFolder.Name = "treeFolder";
            treeFolder.Size = new Size(228, 348);
            treeFolder.TabIndex = 0;
            treeFolder.AfterSelect += treeFolder_AfterSelect;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(dgvFiles);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(266, 16);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(915, 392);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "My Directory Files";
            // 
            // dgvFiles
            // 
            dgvFiles.AllowUserToAddRows = false;
            dgvFiles.AllowUserToDeleteRows = false;
            dgvFiles.AllowUserToResizeColumns = false;
            dgvFiles.AllowUserToResizeRows = false;
            dgvFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFiles.BackgroundColor = Color.White;
            dgvFiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFiles.Location = new Point(3, 37);
            dgvFiles.Margin = new Padding(3, 4, 3, 4);
            dgvFiles.Name = "dgvFiles";
            dgvFiles.RowHeadersWidth = 51;
            dgvFiles.RowTemplate.Height = 25;
            dgvFiles.Size = new Size(909, 349);
            dgvFiles.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1195, 412);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(groupBox3);
            panel2.Location = new Point(0, 439);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1195, 232);
            panel2.TabIndex = 3;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.BackColor = SystemColors.Control;
            groupBox3.Controls.Add(txtRemarks);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(btnSendFile);
            groupBox3.Controls.Add(cboUser);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(btnBrowseFile);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(txtFilePath);
            groupBox3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.Location = new Point(14, 5);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(1168, 209);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Send File";
            // 
            // txtRemarks
            // 
            txtRemarks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtRemarks.Location = new Point(106, 119);
            txtRemarks.Margin = new Padding(3, 4, 3, 4);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(711, 81);
            txtRemarks.TabIndex = 19;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(7, 127);
            label1.Name = "label1";
            label1.Size = new Size(93, 31);
            label1.TabIndex = 18;
            label1.Text = "Remark";
            // 
            // btnSendFile
            // 
            btnSendFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSendFile.BackColor = Color.FromArgb(41, 128, 185);
            btnSendFile.FlatStyle = FlatStyle.Flat;
            btnSendFile.Font = new Font("Verdana", 16F, FontStyle.Bold, GraphicsUnit.Point);
            btnSendFile.ForeColor = Color.White;
            btnSendFile.Location = new Point(838, 28);
            btnSendFile.Margin = new Padding(3, 4, 3, 4);
            btnSendFile.Name = "btnSendFile";
            btnSendFile.Size = new Size(323, 173);
            btnSendFile.TabIndex = 17;
            btnSendFile.Text = "Send File";
            btnSendFile.UseVisualStyleBackColor = false;
            btnSendFile.Click += btnSendFile_Click;
            // 
            // cboUser
            // 
            cboUser.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboUser.FormattingEnabled = true;
            cboUser.Location = new Point(106, 76);
            cboUser.Margin = new Padding(3, 4, 3, 4);
            cboUser.Name = "cboUser";
            cboUser.Size = new Size(711, 36);
            cboUser.TabIndex = 16;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(7, 84);
            label4.Name = "label4";
            label4.Size = new Size(93, 31);
            label4.TabIndex = 15;
            label4.Text = "Select User:";
            // 
            // btnBrowseFile
            // 
            btnBrowseFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseFile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnBrowseFile.Location = new Point(711, 27);
            btnBrowseFile.Margin = new Padding(3, 4, 3, 4);
            btnBrowseFile.Name = "btnBrowseFile";
            btnBrowseFile.Size = new Size(107, 40);
            btnBrowseFile.TabIndex = 14;
            btnBrowseFile.Text = "Browse...";
            btnBrowseFile.UseVisualStyleBackColor = true;
            btnBrowseFile.Click += btnBrowseFile_Click;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(7, 32);
            label3.Name = "label3";
            label3.Size = new Size(93, 40);
            label3.TabIndex = 12;
            label3.Text = "Select File: ";
            // 
            // txtFilePath
            // 
            txtFilePath.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtFilePath.Location = new Point(106, 29);
            txtFilePath.Margin = new Padding(3, 4, 3, 4);
            txtFilePath.Multiline = true;
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new Size(604, 36);
            txtFilePath.TabIndex = 13;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmFileSend
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1195, 669);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmFileSend";
            Text = "File Send";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFiles).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dgvFiles;
        private TreeView treeFolder;
        private Panel panel1;
        private Panel panel2;
        private GroupBox groupBox3;
        private ComboBox cboUser;
        private Label label4;
        private Button btnBrowseFile;
        private Label label3;
        private TextBox txtFilePath;
        private Button btnSendFile;
        private OpenFileDialog openFileDialog1;
        private TextBox txtRemarks;
        private Label label1;
    }
}