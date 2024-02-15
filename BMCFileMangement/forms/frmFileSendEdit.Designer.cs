namespace BMCFileMangement.forms
{
    partial class frmFileSendEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileSendEdit));
            panel1 = new Panel();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            tinyMceEditor = new WinFormTinyMCE.TinyMCE();
            cboPriority = new ComboBox();
            label2 = new Label();
            txtRemarks = new TextBox();
            label1 = new Label();
            cboUser = new ComboBox();
            label4 = new Label();
            btnSendFile = new Button();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1125, 10);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(1125, 644);
            panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tinyMceEditor);
            groupBox1.Controls.Add(cboPriority);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtRemarks);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cboUser);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnSendFile);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1125, 644);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Request Feedback";
            // 
            // tinyMceEditor
            // 
            tinyMceEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tinyMceEditor.HtmlContent = "";
            tinyMceEditor.Location = new Point(148, 213);
            tinyMceEditor.Margin = new Padding(7, 5, 7, 5);
            tinyMceEditor.Name = "tinyMceEditor";
            tinyMceEditor.Size = new Size(900, 352);
            tinyMceEditor.TabIndex = 38;
            // 
            // cboPriority
            // 
            cboPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPriority.FlatStyle = FlatStyle.Flat;
            cboPriority.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboPriority.FormattingEnabled = true;
            cboPriority.Location = new Point(149, 87);
            cboPriority.Margin = new Padding(11, 4, 3, 4);
            cboPriority.Name = "cboPriority";
            cboPriority.Size = new Size(899, 36);
            cboPriority.TabIndex = 30;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(49, 95);
            label2.Name = "label2";
            label2.Size = new Size(93, 31);
            label2.TabIndex = 37;
            label2.Text = "Priority:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtRemarks
            // 
            txtRemarks.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtRemarks.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtRemarks.Location = new Point(148, 131);
            txtRemarks.Margin = new Padding(3, 4, 3, 4);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(900, 73);
            txtRemarks.TabIndex = 31;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(49, 148);
            label1.Name = "label1";
            label1.Size = new Size(93, 31);
            label1.TabIndex = 36;
            label1.Text = "Comment";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cboUser
            // 
            cboUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUser.FlatStyle = FlatStyle.Flat;
            cboUser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboUser.FormattingEnabled = true;
            cboUser.Items.AddRange(new object[] { "Please Select User" });
            cboUser.Location = new Point(149, 40);
            cboUser.Margin = new Padding(11, 4, 3, 4);
            cboUser.MaxDropDownItems = 50;
            cboUser.Name = "cboUser";
            cboUser.Size = new Size(899, 36);
            cboUser.TabIndex = 29;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(49, 48);
            label4.Name = "label4";
            label4.Size = new Size(93, 31);
            label4.TabIndex = 35;
            label4.Text = "To User:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSendFile
            // 
            btnSendFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSendFile.BackColor = Color.FromArgb(41, 128, 185);
            btnSendFile.FlatStyle = FlatStyle.Flat;
            btnSendFile.Font = new Font("Verdana", 16F, FontStyle.Bold, GraphicsUnit.Point);
            btnSendFile.ForeColor = Color.White;
            btnSendFile.Image = (Image)resources.GetObject("btnSendFile.Image");
            btnSendFile.Location = new Point(916, 574);
            btnSendFile.Margin = new Padding(3, 4, 3, 4);
            btnSendFile.Name = "btnSendFile";
            btnSendFile.Size = new Size(132, 48);
            btnSendFile.TabIndex = 32;
            btnSendFile.Text = "Send";
            btnSendFile.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSendFile.UseVisualStyleBackColor = false;
            // 
            // frmFileSendEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 654);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmFileSendEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmFileSendEdit";
            Load += frmFileSendEdit_Load;
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private GroupBox groupBox1;
        private WinFormTinyMCE.TinyMCE tinyMceEditor;
        private ComboBox cboPriority;
        private Label label2;
        private TextBox txtRemarks;
        private Label label1;
        private ComboBox cboUser;
        private Label label4;
        private Button btnSendFile;
    }
}