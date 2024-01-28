namespace BMCFileMangement.forms.UserControls
{
    partial class NotificationDataListViewControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlRadio = new System.Windows.Forms.Panel();
            this.rdoShowNotificaiton = new System.Windows.Forms.RadioButton();
            this.rdoShownew = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtGrdNotification = new System.Windows.Forms.DataGridView();
            this.pnlRadio.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdNotification)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRadio
            // 
            this.pnlRadio.Controls.Add(this.rdoShowNotificaiton);
            this.pnlRadio.Controls.Add(this.rdoShownew);
            this.pnlRadio.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRadio.Location = new System.Drawing.Point(0, 0);
            this.pnlRadio.Name = "pnlRadio";
            this.pnlRadio.Size = new System.Drawing.Size(963, 71);
            this.pnlRadio.TabIndex = 0;
            // 
            // rdoShowNotificaiton
            // 
            this.rdoShowNotificaiton.AutoSize = true;
            this.rdoShowNotificaiton.Location = new System.Drawing.Point(330, 20);
            this.rdoShowNotificaiton.Name = "rdoShowNotificaiton";
            this.rdoShowNotificaiton.Size = new System.Drawing.Size(103, 29);
            this.rdoShowNotificaiton.TabIndex = 1;
            this.rdoShowNotificaiton.TabStop = true;
            this.rdoShowNotificaiton.Text = "Show all";
            this.rdoShowNotificaiton.UseVisualStyleBackColor = true;
            // 
            // rdoShownew
            // 
            this.rdoShownew.AutoSize = true;
            this.rdoShownew.Location = new System.Drawing.Point(493, 20);
            this.rdoShownew.Name = "rdoShownew";
            this.rdoShownew.Size = new System.Drawing.Size(118, 29);
            this.rdoShownew.TabIndex = 0;
            this.rdoShownew.TabStop = true;
            this.rdoShownew.Text = "Show new";
            this.rdoShownew.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtGrdNotification);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(963, 315);
            this.panel2.TabIndex = 1;
            // 
            // dtGrdNotification
            // 
            this.dtGrdNotification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdNotification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGrdNotification.Location = new System.Drawing.Point(0, 0);
            this.dtGrdNotification.Name = "dtGrdNotification";
            this.dtGrdNotification.RowHeadersWidth = 62;
            this.dtGrdNotification.RowTemplate.Height = 33;
            this.dtGrdNotification.Size = new System.Drawing.Size(963, 315);
            this.dtGrdNotification.TabIndex = 0;
            // 
            // NotificationDataListViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlRadio);
            this.Name = "NotificationDataListViewControl";
            this.Size = new System.Drawing.Size(963, 386);
            this.pnlRadio.ResumeLayout(false);
            this.pnlRadio.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdNotification)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlRadio;
        private Panel panel2;
        private RadioButton rdoShowNotificaiton;
        private RadioButton rdoShownew;
        private DataGridView dtGrdNotification;
    }
}
