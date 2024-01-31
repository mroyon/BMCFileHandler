using BMCFileMangement.forms.UserControls;
using BMCFileMangement.Services.Interface;
using Microsoft.Extensions.Logging;
using Windows.Services.Maps;

namespace BMCFileMangement.forms
{
    partial class frmMainWindow
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.ibtnNotification = new FontAwesome.Sharp.IconButton();
            this.ibtnUser = new FontAwesome.Sharp.IconButton();
            this.ibtnDashboard = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panleTitleBar = new System.Windows.Forms.Panel();
            this.btnMaximizes = new FontAwesome.Sharp.IconPictureBox();
            this.btnMinimize = new FontAwesome.Sharp.IconPictureBox();
            this.lblChildFormTitle = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.btnClose = new FontAwesome.Sharp.IconPictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();

            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panleTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.panelBody.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(31, 30, 68);
            panelMenu.Controls.Add(ibtnNotification);
            panelMenu.Controls.Add(ibtnUser);
            panelMenu.Controls.Add(ibtnDashboard);
            panelMenu.Controls.Add(panel1);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(220, 673);
            panelMenu.TabIndex = 0;
            // 
            // ibtnNotification
            // 
            this.ibtnNotification.Dock = System.Windows.Forms.DockStyle.Top;
            this.ibtnNotification.FlatAppearance.BorderSize = 0;
            this.ibtnNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnNotification.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ibtnNotification.ForeColor = System.Drawing.Color.Gainsboro;
            this.ibtnNotification.IconChar = FontAwesome.Sharp.IconChar.ShareFromSquare;
            this.ibtnNotification.IconColor = System.Drawing.Color.White;
            this.ibtnNotification.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnNotification.IconSize = 32;
            this.ibtnNotification.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnNotification.Location = new System.Drawing.Point(0, 260);
            this.ibtnNotification.Name = "ibtnNotification";
            this.ibtnNotification.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ibtnNotification.Size = new System.Drawing.Size(220, 60);
            this.ibtnNotification.TabIndex = 3;
            this.ibtnNotification.Text = "File Send";
            this.ibtnNotification.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnNotification.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtnNotification.UseVisualStyleBackColor = true;
            // 
            // ibtnUser
            // 
            ibtnUser.Dock = DockStyle.Top;
            ibtnUser.FlatAppearance.BorderSize = 0;
            ibtnUser.FlatStyle = FlatStyle.Flat;
            ibtnUser.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ibtnUser.ForeColor = Color.Gainsboro;
            ibtnUser.IconChar = FontAwesome.Sharp.IconChar.User;
            ibtnUser.IconColor = Color.White;
            ibtnUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnUser.IconSize = 32;
            ibtnUser.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnUser.Location = new Point(0, 200);
            ibtnUser.Name = "ibtnUser";
            ibtnUser.Padding = new Padding(10, 0, 20, 0);
            ibtnUser.Size = new Size(220, 60);
            ibtnUser.TabIndex = 2;
            ibtnUser.Text = "User";
            ibtnUser.TextAlign = ContentAlignment.MiddleLeft;
            ibtnUser.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnUser.UseVisualStyleBackColor = true;
            // 
            // ibtnDashboard
            // 
            ibtnDashboard.Dock = DockStyle.Top;
            ibtnDashboard.FlatAppearance.BorderSize = 0;
            ibtnDashboard.FlatStyle = FlatStyle.Flat;
            ibtnDashboard.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ibtnDashboard.ForeColor = Color.Gainsboro;
            ibtnDashboard.IconChar = FontAwesome.Sharp.IconChar.Dashboard;
            ibtnDashboard.IconColor = Color.White;
            ibtnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnDashboard.IconSize = 32;
            ibtnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnDashboard.Location = new Point(0, 140);
            ibtnDashboard.Name = "ibtnDashboard";
            ibtnDashboard.Padding = new Padding(10, 0, 20, 0);
            ibtnDashboard.Size = new Size(220, 60);
            ibtnDashboard.TabIndex = 1;
            ibtnDashboard.Text = "Dashboard";
            ibtnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            ibtnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnDashboard.UseVisualStyleBackColor = true;
            ibtnDashboard.Click += ibtnDashboard_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 140);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 101);
            label2.Name = "label2";
            label2.Size = new Size(217, 25);
            label2.TabIndex = 2;
            label2.Text = "Rabiul Islam RoNy";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 7);
            label1.Name = "label1";
            label1.Size = new Size(217, 25);
            label1.TabIndex = 1;
            label1.Text = "File Management";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panleTitleBar
            // 
            panleTitleBar.BackColor = Color.FromArgb(31, 30, 68);
            panleTitleBar.Controls.Add(btnMaximizes);
            panleTitleBar.Controls.Add(btnMinimize);
            panleTitleBar.Controls.Add(lblChildFormTitle);
            panleTitleBar.Controls.Add(iconCurrentChildForm);
            panleTitleBar.Controls.Add(btnClose);
            panleTitleBar.Dock = DockStyle.Top;
            panleTitleBar.Location = new Point(220, 0);
            panleTitleBar.Name = "panleTitleBar";
            panleTitleBar.Size = new Size(1056, 47);
            panleTitleBar.TabIndex = 1;
            panleTitleBar.MouseDown += panleTitleBar_MouseDown;
            // 
            // btnMaximizes
            // 
            btnMaximizes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximizes.BackColor = Color.FromArgb(31, 30, 68);
            btnMaximizes.IconChar = FontAwesome.Sharp.IconChar.Maximize;
            btnMaximizes.IconColor = Color.White;
            btnMaximizes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMaximizes.IconSize = 30;
            btnMaximizes.Location = new Point(986, 10);
            btnMaximizes.Name = "btnMaximizes";
            btnMaximizes.Size = new Size(30, 30);
            btnMaximizes.TabIndex = 8;
            btnMaximizes.TabStop = false;
            btnMaximizes.Click += btnMaximizes_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.BackColor = Color.FromArgb(31, 30, 68);
            btnMinimize.IconChar = FontAwesome.Sharp.IconChar.Minus;
            btnMinimize.IconColor = Color.White;
            btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMinimize.IconSize = 30;
            btnMinimize.Location = new Point(950, 11);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(30, 30);
            btnMinimize.TabIndex = 7;
            btnMinimize.TabStop = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // lblChildFormTitle
            // 
            lblChildFormTitle.ForeColor = Color.Gainsboro;
            lblChildFormTitle.Location = new Point(43, 13);
            lblChildFormTitle.Name = "lblChildFormTitle";
            lblChildFormTitle.Size = new Size(187, 25);
            lblChildFormTitle.TabIndex = 1;
            lblChildFormTitle.Text = "Home";
            // 
            // iconCurrentChildForm
            // 
            iconCurrentChildForm.BackColor = Color.FromArgb(31, 30, 68);
            iconCurrentChildForm.ForeColor = Color.MediumPurple;
            iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconCurrentChildForm.Location = new Point(5, 7);
            iconCurrentChildForm.Name = "iconCurrentChildForm";
            iconCurrentChildForm.Size = new Size(32, 33);
            iconCurrentChildForm.TabIndex = 0;
            iconCurrentChildForm.TabStop = false;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(31, 30, 68);
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            btnClose.IconColor = Color.White;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.IconSize = 30;
            btnClose.Location = new Point(1022, 11);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 30);
            btnClose.TabIndex = 7;
            btnClose.TabStop = false;
            btnClose.Click += btnClose_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(31, 30, 68);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(220, 47);
            panel2.Name = "panel2";
            panel2.Size = new Size(1056, 9);
            panel2.TabIndex = 2;
            // 
            // panelBody
            // 
            panelBody.Controls.Add(panel4);
            panelBody.Controls.Add(panelDesktop);
            panelBody.Controls.Add(panel3);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(220, 56);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(1056, 617);
            panelBody.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.PowderBlue;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Location = new Point(0, 167);
            panel4.Name = "panel4";
            panel4.Size = new Size(1056, 8);
            panel4.TabIndex = 0;
            // 
            // panelDesktop
            // 
            panelDesktop.Location = new Point(0, 175);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(1062, 441);
            panelDesktop.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1056, 166);
            panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
           
            this.groupBox1.Location = new System.Drawing.Point(0, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1056, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notification Data View";
           
            
            // 
            // frmMainWindow
            // 
            this.ClientSize = new System.Drawing.Size(1276, 673);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panleTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Name = "frmMainWindow";
            this.Text = "BMC File Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panleTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.panelBody.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelMenu;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton ibtnDashboard;
        private FontAwesome.Sharp.IconButton ibtnNotification;
        private FontAwesome.Sharp.IconButton ibtnUser;
        private Label label2;
        private Label label1;
        private Panel panleTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private Label lblChildFormTitle;
        private Panel panel2;
        private Panel panelBody;
        private Button button1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox btnClose;
        private Button button2;
        private FontAwesome.Sharp.IconPictureBox btnMinimize;
        private FontAwesome.Sharp.IconPictureBox btnMaximizes;
        private Panel panel3;
        private Panel panelDesktop;
        private GroupBox groupBox1;
        private Panel panel4;
        private NotificationAndDataQueryBGWorker notificationAndDataQuerybgWorker1;
        private NotificationDataListViewControl notificationDataListViewControl1;
    }
}