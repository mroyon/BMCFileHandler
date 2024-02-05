namespace BMCFileMangement.forms
{
    partial class frmOutBox
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearData = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearchData = new System.Windows.Forms.Button();
            this.dtGrdInBox = new System.Windows.Forms.DataGridView();
            this.filetransid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tousername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sentdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isreceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiveddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.showedpopup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.showeddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isopen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opendate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromuserremark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdInBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.dtGrdInBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 563);
            this.panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPreviousPage);
            this.groupBox2.Controls.Add(this.btnNextPage);
            this.groupBox2.Controls.Add(this.btnFirstPage);
            this.groupBox2.Controls.Add(this.btnLastPage);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 505);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1046, 58);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paging";
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviousPage.Location = new System.Drawing.Point(478, 15);
            this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(46, 28);
            this.btnPreviousPage.TabIndex = 5;
            this.btnPreviousPage.Text = "<";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPage.Location = new System.Drawing.Point(524, 15);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(46, 28);
            this.btnNextPage.TabIndex = 6;
            this.btnNextPage.Text = ">";
            this.btnNextPage.UseVisualStyleBackColor = true;
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirstPage.Location = new System.Drawing.Point(433, 15);
            this.btnFirstPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(46, 28);
            this.btnFirstPage.TabIndex = 8;
            this.btnFirstPage.Text = "<<";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            // 
            // btnLastPage
            // 
            this.btnLastPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLastPage.Location = new System.Drawing.Point(567, 15);
            this.btnLastPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(46, 28);
            this.btnLastPage.TabIndex = 7;
            this.btnLastPage.Text = ">>";
            this.btnLastPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearData);
            this.groupBox1.Controls.Add(this.txtContent);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnSearchData);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1046, 58);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View Out Box Files";
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(656, 22);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(117, 23);
            this.btnClearData.TabIndex = 7;
            this.btnClearData.Text = "Clear";
            this.btnClearData.UseVisualStyleBackColor = true;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(140, 22);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(381, 23);
            this.txtContent.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Content";
            // 
            // btnSearchData
            // 
            this.btnSearchData.Location = new System.Drawing.Point(530, 22);
            this.btnSearchData.Name = "btnSearchData";
            this.btnSearchData.Size = new System.Drawing.Size(117, 23);
            this.btnSearchData.TabIndex = 0;
            this.btnSearchData.Text = "Search";
            this.btnSearchData.UseVisualStyleBackColor = true;
            // 
            // dtGrdInBox
            // 
            this.dtGrdInBox.AllowUserToAddRows = false;
            this.dtGrdInBox.AllowUserToDeleteRows = false;
            this.dtGrdInBox.AllowUserToResizeColumns = false;
            this.dtGrdInBox.AllowUserToResizeRows = false;
            this.dtGrdInBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGrdInBox.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGrdInBox.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGrdInBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdInBox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.filetransid,
            this.tousername,
            this.filename,
            this.priority,
            this.sentdate,
            this.isreceived,
            this.receiveddate,
            this.showedpopup,
            this.showeddate,
            this.isopen,
            this.opendate,
            this.status,
            this.fromuserremark});
            this.dtGrdInBox.EnableHeadersVisualStyles = false;
            this.dtGrdInBox.Location = new System.Drawing.Point(0, 64);
            this.dtGrdInBox.Name = "dtGrdInBox";
            this.dtGrdInBox.RowTemplate.Height = 35;
            this.dtGrdInBox.Size = new System.Drawing.Size(1046, 438);
            this.dtGrdInBox.TabIndex = 0;
            this.dtGrdInBox.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrdInBox_CellClick);
            this.dtGrdInBox.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtGrdInBox_CellFormatting);
            // 
            // filetransid
            // 
            this.filetransid.DataPropertyName = "filetransid";
            this.filetransid.HeaderText = "filetransid";
            this.filetransid.Name = "filetransid";
            this.filetransid.Visible = false;
            // 
            // tousername
            // 
            this.tousername.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tousername.DataPropertyName = "tousername";
            this.tousername.HeaderText = "To User";
            this.tousername.Name = "tousername";
            // 
            // filename
            // 
            this.filename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.filename.DataPropertyName = "filename";
            this.filename.HeaderText = "File Name";
            this.filename.Name = "filename";
            // 
            // priority
            // 
            this.priority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.priority.DataPropertyName = "priority";
            this.priority.HeaderText = "Priority";
            this.priority.Name = "priority";
            this.priority.Width = 85;
            // 
            // sentdate
            // 
            this.sentdate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sentdate.DataPropertyName = "sentdate";
            this.sentdate.HeaderText = "Sent Date";
            this.sentdate.Name = "sentdate";
            this.sentdate.Width = 90;
            // 
            // isreceived
            // 
            this.isreceived.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.isreceived.DataPropertyName = "isreceived";
            this.isreceived.HeaderText = "Is Received?";
            this.isreceived.Name = "isreceived";
            this.isreceived.Width = 106;
            // 
            // receiveddate
            // 
            this.receiveddate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.receiveddate.DataPropertyName = "receiveddate";
            this.receiveddate.HeaderText = "Received Date";
            this.receiveddate.Name = "receiveddate";
            this.receiveddate.Width = 119;
            // 
            // showedpopup
            // 
            this.showedpopup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.showedpopup.DataPropertyName = "showedpopup";
            this.showedpopup.HeaderText = "Is Showed Popup?";
            this.showedpopup.Name = "showedpopup";
            this.showedpopup.Width = 97;
            // 
            // showeddate
            // 
            this.showeddate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.showeddate.DataPropertyName = "showeddate";
            this.showeddate.HeaderText = "Showed Date";
            this.showeddate.Name = "showeddate";
            this.showeddate.Width = 112;
            // 
            // isopen
            // 
            this.isopen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.isopen.DataPropertyName = "isopen";
            this.isopen.HeaderText = "Is Open?";
            this.isopen.Name = "isopen";
            this.isopen.Width = 83;
            // 
            // opendate
            // 
            this.opendate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.opendate.DataPropertyName = "opendate";
            this.opendate.HeaderText = "Open Date";
            this.opendate.Name = "opendate";
            this.opendate.Width = 97;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.Width = 74;
            // 
            // fromuserremark
            // 
            this.fromuserremark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fromuserremark.DataPropertyName = "fromuserremark";
            this.fromuserremark.HeaderText = "Remarks";
            this.fromuserremark.Name = "fromuserremark";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Remark";
            // 
            // cboUser
            // 
            this.cboUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(93, 57);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(623, 23);
            this.cboUser.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(6, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Select User:";
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Location = new System.Drawing.Point(0, 0);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFile.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 30);
            this.label3.TabIndex = 12;
            this.label3.Text = "Select File: ";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(93, 22);
            this.txtFilePath.Multiline = true;
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(529, 28);
            this.txtFilePath.TabIndex = 13;
            // 
            // frmOutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 563);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOutBox";
            this.Text = "Out Box";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdInBox)).EndInit();
            this.ResumeLayout(false);

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
        private Button btnSearchData;
        private GroupBox groupBox2;
        private Button btnPreviousPage;
        private Button btnNextPage;
        private Button btnFirstPage;
        private Button btnLastPage;
        private Label label6;
        private TextBox txtContent;
        private Button btnClearData;
        private DataGridViewTextBoxColumn filetransid;
        private DataGridViewTextBoxColumn tousername;
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