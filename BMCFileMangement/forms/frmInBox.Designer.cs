namespace BMCFileMangement.forms
{
    partial class frmInBox
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            groupBox2 = new GroupBox();
            btnPreviousPage = new Button();
            btnNextPage = new Button();
            btnFirstPage = new Button();
            btnLastPage = new Button();
            groupBox1 = new GroupBox();
            btnClearSearchInboxData = new Button();
            txtContent = new TextBox();
            label6 = new Label();
            btnSearchInboxData = new Button();
            dtGrdInBox = new DataGridView();
            filetransid = new DataGridViewTextBoxColumn();
            fromusername = new DataGridViewTextBoxColumn();
            filename = new DataGridViewTextBoxColumn();
            priority = new DataGridViewTextBoxColumn();
            sentdate = new DataGridViewTextBoxColumn();
            isreceived = new DataGridViewTextBoxColumn();
            receiveddate = new DataGridViewTextBoxColumn();
            showedpopup = new DataGridViewTextBoxColumn();
            showeddate = new DataGridViewTextBoxColumn();
            isopen = new DataGridViewTextBoxColumn();
            opendate = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            fromuserremark = new DataGridViewTextBoxColumn();
            label1 = new Label();
            cboUser = new ComboBox();
            label4 = new Label();
            btnBrowseFile = new Button();
            label3 = new Label();
            txtFilePath = new TextBox();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtGrdInBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(dtGrdInBox);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1195, 751);
            panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnPreviousPage);
            groupBox2.Controls.Add(btnNextPage);
            groupBox2.Controls.Add(btnFirstPage);
            groupBox2.Controls.Add(btnLastPage);
            groupBox2.Dock = DockStyle.Bottom;
            groupBox2.Location = new Point(0, 674);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(1195, 77);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Paging";
            // 
            // btnPreviousPage
            // 
            btnPreviousPage.Anchor = AnchorStyles.None;
            btnPreviousPage.Location = new Point(546, 20);
            btnPreviousPage.Name = "btnPreviousPage";
            btnPreviousPage.Size = new Size(53, 37);
            btnPreviousPage.TabIndex = 5;
            btnPreviousPage.Text = "<";
            btnPreviousPage.UseVisualStyleBackColor = true;
            // 
            // btnNextPage
            // 
            btnNextPage.Anchor = AnchorStyles.None;
            btnNextPage.Location = new Point(599, 20);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(53, 37);
            btnNextPage.TabIndex = 6;
            btnNextPage.Text = ">";
            btnNextPage.UseVisualStyleBackColor = true;
            // 
            // btnFirstPage
            // 
            btnFirstPage.Anchor = AnchorStyles.None;
            btnFirstPage.Location = new Point(495, 20);
            btnFirstPage.Name = "btnFirstPage";
            btnFirstPage.Size = new Size(53, 37);
            btnFirstPage.TabIndex = 8;
            btnFirstPage.Text = "|<";
            btnFirstPage.UseVisualStyleBackColor = true;
            // 
            // btnLastPage
            // 
            btnLastPage.Anchor = AnchorStyles.None;
            btnLastPage.Location = new Point(650, 20);
            btnLastPage.Name = "btnLastPage";
            btnLastPage.Size = new Size(53, 37);
            btnLastPage.TabIndex = 7;
            btnLastPage.Text = ">|";
            btnLastPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClearSearchInboxData);
            groupBox1.Controls.Add(txtContent);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(btnSearchInboxData);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1195, 77);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "View In Box Files";
            // 
            // btnClearSearchInboxData
            // 
            btnClearSearchInboxData.Location = new Point(713, 31);
            btnClearSearchInboxData.Margin = new Padding(3, 4, 3, 4);
            btnClearSearchInboxData.Name = "btnClearSearchInboxData";
            btnClearSearchInboxData.Size = new Size(134, 31);
            btnClearSearchInboxData.TabIndex = 7;
            btnClearSearchInboxData.Text = "Clear";
            btnClearSearchInboxData.UseVisualStyleBackColor = true;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(130, 31);
            txtContent.Margin = new Padding(3, 4, 3, 4);
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(435, 27);
            txtContent.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(66, 36);
            label6.Name = "label6";
            label6.Size = new Size(61, 20);
            label6.TabIndex = 5;
            label6.Text = "Content";
            // 
            // btnSearchInboxData
            // 
            btnSearchInboxData.Location = new Point(573, 31);
            btnSearchInboxData.Margin = new Padding(3, 4, 3, 4);
            btnSearchInboxData.Name = "btnSearchInboxData";
            btnSearchInboxData.Size = new Size(134, 31);
            btnSearchInboxData.TabIndex = 0;
            btnSearchInboxData.Text = "Search";
            btnSearchInboxData.UseVisualStyleBackColor = true;
            // 
            // dtGrdInBox
            // 
            dtGrdInBox.AllowUserToAddRows = false;
            dtGrdInBox.AllowUserToDeleteRows = false;
            dtGrdInBox.AllowUserToResizeColumns = false;
            dtGrdInBox.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dtGrdInBox.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dtGrdInBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtGrdInBox.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Teal;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtGrdInBox.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtGrdInBox.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtGrdInBox.Columns.AddRange(new DataGridViewColumn[] { filetransid, fromusername, filename, priority, sentdate, isreceived, receiveddate, showedpopup, showeddate, isopen, opendate, status, fromuserremark });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.PaleGoldenrod;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dtGrdInBox.DefaultCellStyle = dataGridViewCellStyle4;
            dtGrdInBox.EnableHeadersVisualStyles = false;
            dtGrdInBox.Location = new Point(0, 85);
            dtGrdInBox.Margin = new Padding(3, 4, 3, 4);
            dtGrdInBox.Name = "dtGrdInBox";
            dtGrdInBox.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dtGrdInBox.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dtGrdInBox.RowHeadersWidth = 51;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dtGrdInBox.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dtGrdInBox.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtGrdInBox.RowTemplate.DefaultCellStyle.Padding = new Padding(2);
            dtGrdInBox.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
            dtGrdInBox.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;
            dtGrdInBox.RowTemplate.Height = 35;
            dtGrdInBox.Size = new Size(1195, 584);
            dtGrdInBox.TabIndex = 0;
            dtGrdInBox.CellClick += dtGrdInBox_CellClick;
            dtGrdInBox.CellFormatting += dtGrdInBox_CellFormatting;
            // 
            // filetransid
            // 
            filetransid.DataPropertyName = "filetransid";
            filetransid.HeaderText = "filetransid";
            filetransid.MinimumWidth = 6;
            filetransid.Name = "filetransid";
            filetransid.ReadOnly = true;
            filetransid.Visible = false;
            // 
            // fromusername
            // 
            fromusername.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fromusername.DataPropertyName = "fromusername";
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            fromusername.DefaultCellStyle = dataGridViewCellStyle3;
            fromusername.HeaderText = "From User";
            fromusername.MinimumWidth = 62;
            fromusername.Name = "fromusername";
            fromusername.ReadOnly = true;
            // 
            // filename
            // 
            filename.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            filename.DataPropertyName = "filename";
            filename.HeaderText = "File Name";
            filename.MinimumWidth = 62;
            filename.Name = "filename";
            filename.ReadOnly = true;
            // 
            // priority
            // 
            priority.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            priority.DataPropertyName = "priority";
            priority.HeaderText = "Priority";
            priority.MinimumWidth = 6;
            priority.Name = "priority";
            priority.ReadOnly = true;
            priority.Width = 99;
            // 
            // sentdate
            // 
            sentdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            sentdate.DataPropertyName = "sentdate";
            sentdate.HeaderText = "Sent Date";
            sentdate.MinimumWidth = 6;
            sentdate.Name = "sentdate";
            sentdate.ReadOnly = true;
            sentdate.Width = 118;
            // 
            // isreceived
            // 
            isreceived.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            isreceived.DataPropertyName = "isreceived";
            isreceived.HeaderText = "Is Received?";
            isreceived.MinimumWidth = 6;
            isreceived.Name = "isreceived";
            isreceived.ReadOnly = true;
            isreceived.Width = 134;
            // 
            // receiveddate
            // 
            receiveddate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            receiveddate.DataPropertyName = "receiveddate";
            receiveddate.HeaderText = "Received Date";
            receiveddate.MinimumWidth = 6;
            receiveddate.Name = "receiveddate";
            receiveddate.ReadOnly = true;
            receiveddate.Width = 153;
            // 
            // showedpopup
            // 
            showedpopup.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            showedpopup.DataPropertyName = "showedpopup";
            showedpopup.HeaderText = "Is Popup?";
            showedpopup.MinimumWidth = 6;
            showedpopup.Name = "showedpopup";
            showedpopup.ReadOnly = true;
            showedpopup.Width = 114;
            // 
            // showeddate
            // 
            showeddate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            showeddate.DataPropertyName = "showeddate";
            showeddate.HeaderText = "Popup Date";
            showeddate.MinimumWidth = 6;
            showeddate.Name = "showeddate";
            showeddate.ReadOnly = true;
            showeddate.Width = 133;
            // 
            // isopen
            // 
            isopen.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            isopen.DataPropertyName = "isopen";
            isopen.HeaderText = "Is Open?";
            isopen.MinimumWidth = 6;
            isopen.Name = "isopen";
            isopen.ReadOnly = true;
            isopen.Width = 106;
            // 
            // opendate
            // 
            opendate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            opendate.DataPropertyName = "opendate";
            opendate.HeaderText = "Open Date";
            opendate.MinimumWidth = 6;
            opendate.Name = "opendate";
            opendate.ReadOnly = true;
            opendate.Width = 125;
            // 
            // status
            // 
            status.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            status.DataPropertyName = "status";
            status.HeaderText = "Status";
            status.MinimumWidth = 6;
            status.Name = "status";
            status.ReadOnly = true;
            status.Width = 89;
            // 
            // fromuserremark
            // 
            fromuserremark.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            fromuserremark.DataPropertyName = "fromuserremark";
            fromuserremark.HeaderText = "Remarks";
            fromuserremark.MinimumWidth = 6;
            fromuserremark.Name = "fromuserremark";
            fromuserremark.ReadOnly = true;
            fromuserremark.Width = 108;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(6, 95);
            label1.Name = "label1";
            label1.Size = new Size(81, 23);
            label1.TabIndex = 18;
            label1.Text = "Remark";
            // 
            // cboUser
            // 
            cboUser.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboUser.FormattingEnabled = true;
            cboUser.Location = new Point(93, 57);
            cboUser.Name = "cboUser";
            cboUser.Size = new Size(623, 28);
            cboUser.TabIndex = 16;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(6, 63);
            label4.Name = "label4";
            label4.Size = new Size(81, 23);
            label4.TabIndex = 15;
            label4.Text = "Select User:";
            // 
            // btnBrowseFile
            // 
            btnBrowseFile.Location = new Point(0, 0);
            btnBrowseFile.Name = "btnBrowseFile";
            btnBrowseFile.Size = new Size(75, 23);
            btnBrowseFile.TabIndex = 0;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(6, 24);
            label3.Name = "label3";
            label3.Size = new Size(81, 30);
            label3.TabIndex = 12;
            label3.Text = "Select File: ";
            // 
            // txtFilePath
            // 
            txtFilePath.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtFilePath.Location = new Point(93, 22);
            txtFilePath.Multiline = true;
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new Size(529, 28);
            txtFilePath.TabIndex = 13;
            // 
            // frmInBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1195, 751);
            ControlBox = false;
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmInBox";
            Text = "In Box";
            Load += frmInBox_Load;
            panel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtGrdInBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private ComboBox cboUser;
        private Label label4;
        private Button btnBrowseFile;
        private Label label3;
        private TextBox txtFilePath;
        private Label label1;
        private DataGridView dtGrdInBox;
        private GroupBox groupBox1;
        private Button btnSearchInboxData;
        private GroupBox groupBox2;
        private Button btnPreviousPage;
        private Button btnNextPage;
        private Button btnFirstPage;
        private Button btnLastPage;
        private Label label6;
        private TextBox txtContent;
        private Button btnClearSearchInboxData;
        private DataGridViewTextBoxColumn filetransid;
        private DataGridViewTextBoxColumn fromusername;
        private DataGridViewTextBoxColumn filename;
        private DataGridViewTextBoxColumn priority;
        private DataGridViewTextBoxColumn sentdate;
        private DataGridViewTextBoxColumn isreceived;
        private DataGridViewTextBoxColumn receiveddate;
        private DataGridViewTextBoxColumn showedpopup;
        private DataGridViewTextBoxColumn showeddate;
        private DataGridViewTextBoxColumn isopen;
        private DataGridViewTextBoxColumn opendate;
        private DataGridViewTextBoxColumn status;
        private DataGridViewTextBoxColumn fromuserremark;
    }
}