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
            this.icnBtnChangePassword = new FontAwesome.Sharp.IconButton();
            this.icnBtnViewOutBox = new FontAwesome.Sharp.IconButton();
            this.icnBtnViewInBox = new FontAwesome.Sharp.IconButton();
            this.ibtnNotification = new FontAwesome.Sharp.IconButton();
            this.ibtnUser = new FontAwesome.Sharp.IconButton();
            this.ibtnDashboard = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panleTitleBar = new System.Windows.Forms.Panel();
            this.icnBtnLogout = new FontAwesome.Sharp.IconButton();
            this.btnMaximizes = new FontAwesome.Sharp.IconPictureBox();
            this.btnMinimize = new FontAwesome.Sharp.IconPictureBox();
            this.lblChildFormTitle = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.btnClose = new FontAwesome.Sharp.IconPictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.pieChartInOut = new Syncfusion.Windows.Forms.Chart.ChartControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panleTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.panelBody.SuspendLayout();
            this.panelDesktop.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelMenu.Controls.Add(this.icnBtnChangePassword);
            this.panelMenu.Controls.Add(this.icnBtnViewOutBox);
            this.panelMenu.Controls.Add(this.icnBtnViewInBox);
            this.panelMenu.Controls.Add(this.ibtnNotification);
            this.panelMenu.Controls.Add(this.ibtnUser);
            this.panelMenu.Controls.Add(this.ibtnDashboard);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 673);
            this.panelMenu.TabIndex = 0;
            // 
            // icnBtnChangePassword
            // 
            this.icnBtnChangePassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.icnBtnChangePassword.FlatAppearance.BorderSize = 0;
            this.icnBtnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnBtnChangePassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.icnBtnChangePassword.ForeColor = System.Drawing.Color.Gainsboro;
            this.icnBtnChangePassword.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.icnBtnChangePassword.IconColor = System.Drawing.Color.White;
            this.icnBtnChangePassword.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnBtnChangePassword.IconSize = 32;
            this.icnBtnChangePassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icnBtnChangePassword.Location = new System.Drawing.Point(0, 406);
            this.icnBtnChangePassword.Name = "icnBtnChangePassword";
            this.icnBtnChangePassword.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.icnBtnChangePassword.Size = new System.Drawing.Size(220, 60);
            this.icnBtnChangePassword.TabIndex = 6;
            this.icnBtnChangePassword.Text = "Change Password";
            this.icnBtnChangePassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icnBtnChangePassword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icnBtnChangePassword.UseVisualStyleBackColor = true;
            this.icnBtnChangePassword.Click += new System.EventHandler(this.icnBtnChangePassword_Click);
            // 
            // icnBtnViewOutBox
            // 
            this.icnBtnViewOutBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.icnBtnViewOutBox.FlatAppearance.BorderSize = 0;
            this.icnBtnViewOutBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnBtnViewOutBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.icnBtnViewOutBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.icnBtnViewOutBox.IconChar = FontAwesome.Sharp.IconChar.LevelUp;
            this.icnBtnViewOutBox.IconColor = System.Drawing.Color.White;
            this.icnBtnViewOutBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnBtnViewOutBox.IconSize = 32;
            this.icnBtnViewOutBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icnBtnViewOutBox.Location = new System.Drawing.Point(0, 346);
            this.icnBtnViewOutBox.Name = "icnBtnViewOutBox";
            this.icnBtnViewOutBox.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.icnBtnViewOutBox.Size = new System.Drawing.Size(220, 60);
            this.icnBtnViewOutBox.TabIndex = 5;
            this.icnBtnViewOutBox.Text = "View OutBox";
            this.icnBtnViewOutBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icnBtnViewOutBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icnBtnViewOutBox.UseVisualStyleBackColor = true;
            // 
            // icnBtnViewInBox
            // 
            this.icnBtnViewInBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.icnBtnViewInBox.FlatAppearance.BorderSize = 0;
            this.icnBtnViewInBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnBtnViewInBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.icnBtnViewInBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.icnBtnViewInBox.IconChar = FontAwesome.Sharp.IconChar.Inbox;
            this.icnBtnViewInBox.IconColor = System.Drawing.Color.White;
            this.icnBtnViewInBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnBtnViewInBox.IconSize = 32;
            this.icnBtnViewInBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icnBtnViewInBox.Location = new System.Drawing.Point(0, 286);
            this.icnBtnViewInBox.Name = "icnBtnViewInBox";
            this.icnBtnViewInBox.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.icnBtnViewInBox.Size = new System.Drawing.Size(220, 60);
            this.icnBtnViewInBox.TabIndex = 4;
            this.icnBtnViewInBox.Text = "View InBox";
            this.icnBtnViewInBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icnBtnViewInBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icnBtnViewInBox.UseVisualStyleBackColor = true;
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
            this.ibtnNotification.Location = new System.Drawing.Point(0, 226);
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
            this.ibtnUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.ibtnUser.FlatAppearance.BorderSize = 0;
            this.ibtnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ibtnUser.ForeColor = System.Drawing.Color.Gainsboro;
            this.ibtnUser.IconChar = FontAwesome.Sharp.IconChar.User;
            this.ibtnUser.IconColor = System.Drawing.Color.White;
            this.ibtnUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnUser.IconSize = 32;
            this.ibtnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnUser.Location = new System.Drawing.Point(0, 166);
            this.ibtnUser.Name = "ibtnUser";
            this.ibtnUser.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ibtnUser.Size = new System.Drawing.Size(220, 60);
            this.ibtnUser.TabIndex = 2;
            this.ibtnUser.Text = "User";
            this.ibtnUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtnUser.UseVisualStyleBackColor = true;
            // 
            // ibtnDashboard
            // 
            this.ibtnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.ibtnDashboard.FlatAppearance.BorderSize = 0;
            this.ibtnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ibtnDashboard.ForeColor = System.Drawing.Color.Gainsboro;
            this.ibtnDashboard.IconChar = FontAwesome.Sharp.IconChar.Dashboard;
            this.ibtnDashboard.IconColor = System.Drawing.Color.White;
            this.ibtnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnDashboard.IconSize = 32;
            this.ibtnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnDashboard.Location = new System.Drawing.Point(0, 106);
            this.ibtnDashboard.Name = "ibtnDashboard";
            this.ibtnDashboard.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ibtnDashboard.Size = new System.Drawing.Size(220, 60);
            this.ibtnDashboard.TabIndex = 1;
            this.ibtnDashboard.Text = "Dashboard";
            this.ibtnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtnDashboard.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 106);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BMCFileMangement.Properties.Resources.Picture1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btnHomeLogo_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblUserName.Location = new System.Drawing.Point(3, 62);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(217, 25);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "BMC File Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.btnHomeLogo_Click);
            // 
            // panleTitleBar
            // 
            this.panleTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panleTitleBar.Controls.Add(this.icnBtnLogout);
            this.panleTitleBar.Controls.Add(this.btnMaximizes);
            this.panleTitleBar.Controls.Add(this.btnMinimize);
            this.panleTitleBar.Controls.Add(this.lblChildFormTitle);
            this.panleTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panleTitleBar.Controls.Add(this.btnClose);
            this.panleTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panleTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panleTitleBar.Name = "panleTitleBar";
            this.panleTitleBar.Size = new System.Drawing.Size(1056, 47);
            this.panleTitleBar.TabIndex = 1;
            // 
            // icnBtnLogout
            // 
            this.icnBtnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.icnBtnLogout.FlatAppearance.BorderSize = 0;
            this.icnBtnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnBtnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.icnBtnLogout.ForeColor = System.Drawing.Color.Gainsboro;
            this.icnBtnLogout.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.icnBtnLogout.IconColor = System.Drawing.Color.White;
            this.icnBtnLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnBtnLogout.IconSize = 32;
            this.icnBtnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icnBtnLogout.Location = new System.Drawing.Point(888, 9);
            this.icnBtnLogout.Name = "icnBtnLogout";
            this.icnBtnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.icnBtnLogout.Size = new System.Drawing.Size(56, 35);
            this.icnBtnLogout.TabIndex = 7;
            this.icnBtnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.icnBtnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.icnBtnLogout.UseVisualStyleBackColor = true;
            this.icnBtnLogout.Click += new System.EventHandler(this.icnBtnLogout_Click);
            // 
            // btnMaximizes
            // 
            this.btnMaximizes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnMaximizes.IconChar = FontAwesome.Sharp.IconChar.Maximize;
            this.btnMaximizes.IconColor = System.Drawing.Color.White;
            this.btnMaximizes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMaximizes.IconSize = 30;
            this.btnMaximizes.Location = new System.Drawing.Point(986, 10);
            this.btnMaximizes.Name = "btnMaximizes";
            this.btnMaximizes.Size = new System.Drawing.Size(30, 30);
            this.btnMaximizes.TabIndex = 8;
            this.btnMaximizes.TabStop = false;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimize.IconSize = 30;
            this.btnMinimize.Location = new System.Drawing.Point(950, 11);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 7;
            this.btnMinimize.TabStop = false;
            // 
            // lblChildFormTitle
            // 
            this.lblChildFormTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblChildFormTitle.Location = new System.Drawing.Point(43, 13);
            this.lblChildFormTitle.Name = "lblChildFormTitle";
            this.lblChildFormTitle.Size = new System.Drawing.Size(187, 25);
            this.lblChildFormTitle.TabIndex = 1;
            this.lblChildFormTitle.Text = "Home";
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(5, 7);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(32, 33);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 30;
            this.btnClose.Location = new System.Drawing.Point(1022, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(220, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1056, 9);
            this.panel2.TabIndex = 2;
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.panelDesktop);
            this.panelBody.Controls.Add(this.panel3);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(220, 56);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(1056, 617);
            this.panelBody.TabIndex = 3;
            // 
            // panelDesktop
            // 
            this.panelDesktop.Controls.Add(this.pieChartInOut);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(0, 0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1056, 617);
            this.panelDesktop.TabIndex = 1;
            // 
            // pieChartInOut
            // 
            this.pieChartInOut.ChartArea.CursorLocation = new System.Drawing.Point(0, 0);
            this.pieChartInOut.ChartArea.CursorReDraw = false;
            this.pieChartInOut.IsWindowLess = false;
            // 
            // 
            // 
            this.pieChartInOut.Legend.Location = new System.Drawing.Point(336, 75);
            this.pieChartInOut.Localize = null;
            this.pieChartInOut.Location = new System.Drawing.Point(66, 50);
            this.pieChartInOut.Name = "pieChartInOut";
            this.pieChartInOut.PrimaryXAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            this.pieChartInOut.PrimaryXAxis.Margin = true;
            this.pieChartInOut.PrimaryYAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            this.pieChartInOut.PrimaryYAxis.Margin = true;
            this.pieChartInOut.Size = new System.Drawing.Size(445, 366);
            this.pieChartInOut.TabIndex = 0;
            this.pieChartInOut.Text = "Inbox Outbox Statistics";
            // 
            // 
            // 
            this.pieChartInOut.Title.Name = "Default";
            this.pieChartInOut.Titles.Add(this.pieChartInOut.Title);
            this.pieChartInOut.VisualTheme = "";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1056, 166);
            this.panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1056, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notification Data View";
            this.groupBox1.Visible = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panleTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.panelBody.ResumeLayout(false);
            this.panelDesktop.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelMenu;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton ibtnDashboard;
        private FontAwesome.Sharp.IconButton ibtnNotification;
        private FontAwesome.Sharp.IconButton ibtnUser;
        private Label lblUserName;
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
        private NotificationAndDataQueryBGWorker notificationAndDataQuerybgWorker1;
        //private NotificationDataListViewControl notificationDataListViewControl1;
        private GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton icnBtnViewOutBox;
        private FontAwesome.Sharp.IconButton icnBtnViewInBox;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton icnBtnChangePassword;
        private PictureBox pictureBox2;
        private FontAwesome.Sharp.IconButton icnBtnLogout;
        private Syncfusion.Windows.Forms.Chart.ChartControl pieChartInOut;
    }
}