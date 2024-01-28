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
            panel2 = new Panel();
            listView1 = new ListView();
            rdoShownew = new RadioButton();
            rdoShowNotificaiton = new RadioButton();
            pnlRadio.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRadio
            // 
            pnlRadio.Controls.Add(rdoShowNotificaiton);
            pnlRadio.Controls.Add(rdoShownew);
            pnlRadio.Dock = DockStyle.Top;
            pnlRadio.Location = new Point(0, 0);
            pnlRadio.Name = "pnlRadio";
            pnlRadio.Size = new Size(963, 71);
            pnlRadio.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(listView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 71);
            panel2.Name = "panel2";
            panel2.Size = new Size(963, 315);
            panel2.TabIndex = 1;
            // 
            // listView1
            // 
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(963, 315);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // rdoShownew
            // 
            rdoShownew.AutoSize = true;
            rdoShownew.Location = new Point(493, 20);
            rdoShownew.Name = "rdoShownew";
            rdoShownew.Size = new Size(118, 29);
            rdoShownew.TabIndex = 0;
            rdoShownew.TabStop = true;
            rdoShownew.Text = "Show new";
            rdoShownew.UseVisualStyleBackColor = true;
            // 
            // rdoShowNotificaiton
            // 
            rdoShowNotificaiton.AutoSize = true;
            rdoShowNotificaiton.Location = new Point(330, 20);
            rdoShowNotificaiton.Name = "rdoShowNotificaiton";
            rdoShowNotificaiton.Size = new Size(103, 29);
            rdoShowNotificaiton.TabIndex = 1;
            rdoShowNotificaiton.TabStop = true;
            rdoShowNotificaiton.Text = "Show all";
            rdoShowNotificaiton.UseVisualStyleBackColor = true;
            // 
            // NotificationDataListViewControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(pnlRadio);
            Name = "NotificationDataListViewControl";
            Size = new Size(963, 386);
            pnlRadio.ResumeLayout(false);
            pnlRadio.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRadio;
        private Panel panel2;
        private ListView listView1;
        private RadioButton rdoShowNotificaiton;
        private RadioButton rdoShownew;
    }
}
