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
            pnlRadio = new Panel();
            rdoShowNotificaiton = new RadioButton();
            rdoShownew = new RadioButton();
            panel2 = new Panel();
            dtGrdNotification = new DataGridView();
            pnlRadio.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtGrdNotification).BeginInit();
            SuspendLayout();
            // 
            // pnlRadio
            // 
            pnlRadio.Controls.Add(rdoShowNotificaiton);
            pnlRadio.Controls.Add(rdoShownew);
            pnlRadio.Dock = DockStyle.Top;
            pnlRadio.Location = new Point(0, 0);
            pnlRadio.Margin = new Padding(2);
            pnlRadio.Name = "pnlRadio";
            pnlRadio.Size = new Size(770, 57);
            pnlRadio.TabIndex = 0;
            // 
            // rdoShowNotificaiton
            // 
            rdoShowNotificaiton.AutoSize = true;
            rdoShowNotificaiton.Location = new Point(264, 16);
            rdoShowNotificaiton.Margin = new Padding(2);
            rdoShowNotificaiton.Name = "rdoShowNotificaiton";
            rdoShowNotificaiton.Size = new Size(86, 24);
            rdoShowNotificaiton.TabIndex = 1;
            rdoShowNotificaiton.TabStop = true;
            rdoShowNotificaiton.Text = "Show all";
            rdoShowNotificaiton.UseVisualStyleBackColor = true;
            // 
            // rdoShownew
            // 
            rdoShownew.AutoSize = true;
            rdoShownew.Location = new Point(394, 16);
            rdoShownew.Margin = new Padding(2);
            rdoShownew.Name = "rdoShownew";
            rdoShownew.Size = new Size(97, 24);
            rdoShownew.TabIndex = 0;
            rdoShownew.TabStop = true;
            rdoShownew.Text = "Show new";
            rdoShownew.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(dtGrdNotification);
            panel2.Location = new Point(0, 57);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(770, 252);
            panel2.TabIndex = 1;
            // 
            // dtGrdNotification
            // 
            dtGrdNotification.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtGrdNotification.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtGrdNotification.Location = new Point(0, 0);
            dtGrdNotification.Margin = new Padding(2);
            dtGrdNotification.Name = "dtGrdNotification";
            dtGrdNotification.RowHeadersWidth = 62;
            dtGrdNotification.RowTemplate.Height = 33;
            dtGrdNotification.Size = new Size(770, 250);
            dtGrdNotification.TabIndex = 0;
            // 
            // NotificationDataListViewControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(pnlRadio);
            Margin = new Padding(2);
            Name = "NotificationDataListViewControl";
            Size = new Size(770, 309);
            pnlRadio.ResumeLayout(false);
            pnlRadio.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtGrdNotification).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRadio;
        private Panel panel2;
        private RadioButton rdoShowNotificaiton;
        private RadioButton rdoShownew;
        private DataGridView dtGrdNotification;
    }
}
