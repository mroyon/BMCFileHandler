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
            panelMenu = new Panel();
            ibtnNotification = new FontAwesome.Sharp.IconButton();
            ibtnUser = new FontAwesome.Sharp.IconButton();
            ibtnDashboard = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panleTitleBar = new Panel();
            btnMaximizes = new FontAwesome.Sharp.IconPictureBox();
            btnMinimize = new FontAwesome.Sharp.IconPictureBox();
            lblChildFormTitle = new Label();
            iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            btnClose = new FontAwesome.Sharp.IconPictureBox();
            panel2 = new Panel();
            panelBody = new Panel();
            panelDesktop = new Panel();
            panel3 = new Panel();
            groupBox1 = new GroupBox();
            panel4 = new Panel();
            panelMenu.SuspendLayout();
            panel1.SuspendLayout();
            panleTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnMaximizes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnClose).BeginInit();
            panelBody.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
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
            ibtnNotification.Dock = DockStyle.Top;
            ibtnNotification.FlatAppearance.BorderSize = 0;
            ibtnNotification.FlatStyle = FlatStyle.Flat;
            ibtnNotification.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ibtnNotification.ForeColor = Color.Gainsboro;
            ibtnNotification.IconChar = FontAwesome.Sharp.IconChar.ShareFromSquare;
            ibtnNotification.IconColor = Color.White;
            ibtnNotification.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibtnNotification.IconSize = 32;
            ibtnNotification.ImageAlign = ContentAlignment.MiddleLeft;
            ibtnNotification.Location = new Point(0, 260);
            ibtnNotification.Name = "ibtnNotification";
            ibtnNotification.Padding = new Padding(10, 0, 20, 0);
            ibtnNotification.Size = new Size(220, 60);
            ibtnNotification.TabIndex = 3;
            ibtnNotification.Text = "File Send";
            ibtnNotification.TextAlign = ContentAlignment.MiddleLeft;
            ibtnNotification.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibtnNotification.UseVisualStyleBackColor = true;
            ibtnNotification.Click += ibtnNotification_Click;
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
            ibtnUser.Click += ibtnUser_Click;
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
            panleTitleBar.Size = new Size(1062, 47);
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
            btnMaximizes.Location = new Point(992, 10);
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
            btnMinimize.Location = new Point(956, 11);
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
            btnClose.Location = new Point(1028, 11);
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
            panel2.Size = new Size(1062, 9);
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
            panelBody.Size = new Size(1062, 617);
            panelBody.TabIndex = 3;
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
            panel3.Size = new Size(1062, 166);
            panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Location = new Point(0, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1062, 157);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Notification Data View";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.PowderBlue;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Location = new Point(0, 167);
            panel4.Name = "panel4";
            panel4.Size = new Size(1062, 8);
            panel4.TabIndex = 0;
            // 
            // frmMainWindow
            // 
            ClientSize = new Size(1282, 673);
            Controls.Add(panelBody);
            Controls.Add(panel2);
            Controls.Add(panleTitleBar);
            Controls.Add(panelMenu);
            Name = "frmMainWindow";
            Text = "BMC File Management";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmMainWindow_FormClosing;
            Load += frmMainWindow_Load;
            panelMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panleTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnMaximizes).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimize).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnClose).EndInit();
            panelBody.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
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
        private NotificationDataListViewControl notificationDataListViewControl1;
        private NotificationAndDataQueryBGWorker notificationAndDataQuerybgWorker1;
        private Panel panelDesktop;
        private GroupBox groupBox1;
        private Panel panel4;
    }
}