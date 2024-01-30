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
            treeView1 = new TreeView();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            panel2 = new Panel();
            groupBox3 = new GroupBox();
            btnSave = new Button();
            cboUser = new ComboBox();
            label4 = new Label();
            btnBrowseFile = new Button();
            label3 = new Label();
            txtFilePath = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(treeView1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(242, 264);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "My Directory";
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            treeView1.BackColor = Color.PowderBlue;
            treeView1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            treeView1.Location = new Point(7, 37);
            treeView1.Margin = new Padding(3, 4, 3, 4);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(228, 220);
            treeView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(266, 16);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(915, 264);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "My Directory Files";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 37);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(909, 221);
            dataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1195, 284);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(groupBox3);
            panel2.Location = new Point(0, 311);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1195, 232);
            panel2.TabIndex = 3;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.BackColor = SystemColors.Control;
            groupBox3.Controls.Add(btnSave);
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
            groupBox3.Size = new Size(1168, 144);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Send File";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(41, 128, 185);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Verdana", 16F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(838, 28);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(323, 92);
            btnSave.TabIndex = 17;
            btnSave.Text = "Send File";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // cboUser
            // 
            cboUser.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboUser.FormattingEnabled = true;
            cboUser.Location = new Point(106, 81);
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
            txtFilePath.Location = new Point(106, 28);
            txtFilePath.Margin = new Padding(3, 4, 3, 4);
            txtFilePath.Multiline = true;
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new Size(604, 36);
            txtFilePath.TabIndex = 13;
            // 
            // frmFileSend
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1195, 541);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmFileSend";
            Text = "File Send";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private TreeView treeView1;
        private Panel panel1;
        private Panel panel2;
        private GroupBox groupBox3;
        private ComboBox cboUser;
        private Label label4;
        private Button btnBrowseFile;
        private Label label3;
        private TextBox txtFilePath;
        private Button btnSave;
    }
}