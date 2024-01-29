using BMCFileMangement.forms.UserControls;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainWindow));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.ibtnNotification = new FontAwesome.Sharp.IconButton();
            this.ibtnUser = new FontAwesome.Sharp.IconButton();
            this.ibtnDashboard = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHomeLogo = new System.Windows.Forms.PictureBox();
            this.panleTitleBar = new System.Windows.Forms.Panel();
            this.btnMaximizes = new FontAwesome.Sharp.IconPictureBox();
            this.btnMinimize = new FontAwesome.Sharp.IconPictureBox();
            this.lblChildFormTitle = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.btnClose = new FontAwesome.Sharp.IconPictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHomeLogo)).BeginInit();
            this.panleTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.panelDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
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
            // ibtnNotification
            // 
            this.ibtnNotification.Dock = System.Windows.Forms.DockStyle.Top;
            this.ibtnNotification.FlatAppearance.BorderSize = 0;
            this.ibtnNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtnNotification.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ibtnNotification.ForeColor = System.Drawing.Color.Gainsboro;
            this.ibtnNotification.IconChar = FontAwesome.Sharp.IconChar.Message;
            this.ibtnNotification.IconColor = System.Drawing.Color.White;
            this.ibtnNotification.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnNotification.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnNotification.Location = new System.Drawing.Point(0, 260);
            this.ibtnNotification.Name = "ibtnNotification";
            this.ibtnNotification.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ibtnNotification.Size = new System.Drawing.Size(220, 60);
            this.ibtnNotification.TabIndex = 3;
            this.ibtnNotification.Text = "Notification";
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
            this.ibtnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnUser.Location = new System.Drawing.Point(0, 200);
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
            this.ibtnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtnDashboard.Location = new System.Drawing.Point(0, 140);
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
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnHomeLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 140);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rabiul Islam RoNy";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "BMC File Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHomeLogo
            // 
            this.btnHomeLogo.Image = ((System.Drawing.Image)(resources.GetObject("btnHomeLogo.Image")));
            this.btnHomeLogo.Location = new System.Drawing.Point(69, 12);
            this.btnHomeLogo.Name = "btnHomeLogo";
            this.btnHomeLogo.Size = new System.Drawing.Size(65, 51);
            this.btnHomeLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHomeLogo.TabIndex = 0;
            this.btnHomeLogo.TabStop = false;
            // 
            // panleTitleBar
            // 
            this.panleTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panleTitleBar.Controls.Add(this.btnMaximizes);
            this.panleTitleBar.Controls.Add(this.btnMinimize);
            this.panleTitleBar.Controls.Add(this.lblChildFormTitle);
            this.panleTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panleTitleBar.Controls.Add(this.btnClose);
            this.panleTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panleTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panleTitleBar.Name = "panleTitleBar";
            this.panleTitleBar.Size = new System.Drawing.Size(1062, 47);
            this.panleTitleBar.TabIndex = 1;
            // 
            // btnMaximizes
            // 
            this.btnMaximizes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnMaximizes.IconChar = FontAwesome.Sharp.IconChar.Maximize;
            this.btnMaximizes.IconColor = System.Drawing.Color.White;
            this.btnMaximizes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMaximizes.IconSize = 30;
            this.btnMaximizes.Location = new System.Drawing.Point(992, 10);
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
            this.btnMinimize.Location = new System.Drawing.Point(956, 11);
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
            this.btnClose.Location = new System.Drawing.Point(1028, 11);
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
            this.panel2.Size = new System.Drawing.Size(1062, 9);
            this.panel2.TabIndex = 2;
            // 
            // panelDesktop
            // 
            this.panelDesktop.Controls.Add(this.panel3);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(220, 56);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1062, 617);
            this.panelDesktop.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1062, 166);
            this.panel3.TabIndex = 0;
            // 
            // frmMainWindow
            // 
            this.ClientSize = new System.Drawing.Size(1282, 673);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panleTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Name = "frmMainWindow";
            this.Text = "BMC File Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainWindow_FormClosing);
            this.Load += new System.EventHandler(this.frmMainWindow_Load);
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHomeLogo)).EndInit();
            this.panleTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.panelDesktop.ResumeLayout(false);
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
        private PictureBox btnHomeLogo;
        private Panel panleTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private Label lblChildFormTitle;
        private Panel panel2;
        private Panel panelDesktop;
        private Button button1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox btnClose;
        private Button button2;
        private FontAwesome.Sharp.IconPictureBox btnMinimize;
        private FontAwesome.Sharp.IconPictureBox btnMaximizes;
        private Panel panel3;
        private NotificationDataListViewControl notificationDataListViewControl1;
        private NotificationAndDataQueryBGWorker notificationAndDataQuerybgWorker1;
    }
}