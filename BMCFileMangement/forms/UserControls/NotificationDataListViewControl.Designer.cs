﻿namespace BMCFileMangement.forms.UserControls
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtGrdNotification = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdNotification)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dtGrdNotification);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1054, 149);
            this.panel2.TabIndex = 1;
            // 
            // dtGrdNotification
            // 
            this.dtGrdNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGrdNotification.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtGrdNotification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdNotification.Location = new System.Drawing.Point(0, 0);
            this.dtGrdNotification.Margin = new System.Windows.Forms.Padding(2);
            this.dtGrdNotification.Name = "dtGrdNotification";
            this.dtGrdNotification.ReadOnly = true;
            this.dtGrdNotification.RowHeadersWidth = 62;
            this.dtGrdNotification.RowTemplate.Height = 33;
            this.dtGrdNotification.Size = new System.Drawing.Size(1052, 143);
            this.dtGrdNotification.TabIndex = 1;
            this.dtGrdNotification.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrdNotification_CellClick);
            // 
            // NotificationDataListViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NotificationDataListViewControl";
            this.Size = new System.Drawing.Size(1056, 166);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdNotification)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel2;
        private DataGridView dtGrdNotification;
    }
}
