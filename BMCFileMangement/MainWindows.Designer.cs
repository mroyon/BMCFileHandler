namespace BMCFileMangement
{
    partial class MainWindows
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindows));
            this.statStrip = new System.Windows.Forms.StatusStrip();
            this.currentDateTimeStip = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusDateTime = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnChangePass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.mnLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statStrip
            // 
            this.statStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentDateTimeStip});
            this.statStrip.Location = new System.Drawing.Point(0, 428);
            this.statStrip.Name = "statStrip";
            this.statStrip.Size = new System.Drawing.Size(800, 22);
            this.statStrip.TabIndex = 1;
            this.statStrip.Text = "statusStrip1";
            // 
            // currentDateTimeStip
            // 
            this.currentDateTimeStip.Name = "currentDateTimeStip";
            this.currentDateTimeStip.Size = new System.Drawing.Size(0, 15);
            // 
            // statusDateTime
            // 
            this.statusDateTime.Enabled = true;
            this.statusDateTime.Interval = 1000;
            this.statusDateTime.Tick += new System.EventHandler(this.statusDateTime_Tick);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnChangePass});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 33);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "File";
            // 
            // mnChangePass
            // 
            this.mnChangePass.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnChangePassword,
            this.mnLogOut});
            this.mnChangePass.Name = "mnChangePass";
            this.mnChangePass.Size = new System.Drawing.Size(147, 29);
            this.mnChangePass.Text = "Profile Manage";
            // 
            // mnChangePassword
            // 
            this.mnChangePassword.Name = "mnChangePassword";
            this.mnChangePassword.Size = new System.Drawing.Size(254, 34);
            this.mnChangePassword.Text = "Change Password";
            // 
            // mnLogOut
            // 
            this.mnLogOut.Name = "mnLogOut";
            this.mnLogOut.Size = new System.Drawing.Size(254, 34);
            this.mnLogOut.Text = "Log Out";
            this.mnLogOut.Click += new System.EventHandler(this.mnLogOut_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip.Location = new System.Drawing.Point(0, 33);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(800, 41);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(196, 36);
            this.toolStripButton1.Text = "Upload For Review";
            // 
            // MainWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BMC File Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWindows_Load);
            this.statStrip.ResumeLayout(false);
            this.statStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip statStrip;
        private ToolStripStatusLabel currentDateTimeStip;
        private System.Windows.Forms.Timer statusDateTime;
        private MenuStrip menuStrip;
        private ToolStripMenuItem mnChangePass;
        private ToolStrip toolStrip;
        private ToolStripMenuItem mnChangePassword;
        private ToolStripMenuItem mnLogOut;
        private ToolStripButton toolStripButton1;
    }
}