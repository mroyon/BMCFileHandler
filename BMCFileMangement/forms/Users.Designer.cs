namespace BMCFileMangement.forms
{
    partial class Users
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
            components = new System.ComponentModel.Container();
            groupBox2 = new GroupBox();
            txtUserID = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtName = new TextBox();
            label3 = new Label();
            label1 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            label6 = new Label();
            label5 = new Label();
            lblMilitaryNo = new Label();
            txtMilitaryNo = new TextBox();
            txtEmail = new TextBox();
            label4 = new Label();
            btnAddUser = new FontAwesome.Sharp.IconButton();
            btnPreviousPage = new Button();
            btnFirstPage = new Button();
            btnNextPage = new Button();
            btnLastPage = new Button();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            pnlPager = new Panel();
            dgvUsers = new DataGridView();
            SLNo = new DataGridViewTextBoxColumn();
            UserID = new DataGridViewTextBoxColumn();
            UserName = new DataGridViewTextBoxColumn();
            FullName = new DataGridViewTextBoxColumn();
            MilitaryNo = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Edit = new DataGridViewImageColumn();
            errorProvider1 = new ErrorProvider(components);
            errorProvider2 = new ErrorProvider(components);
            errorProvider3 = new ErrorProvider(components);
            groupBox2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            pnlPager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider3).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(txtUserID);
            groupBox2.Controls.Add(tableLayoutPanel1);
            groupBox2.Controls.Add(btnAddUser);
            groupBox2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.Location = new Point(11, 13);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(958, 228);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Create User";
            // 
            // txtUserID
            // 
            txtUserID.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUserID.Location = new Point(157, 160);
            txtUserID.Margin = new Padding(3, 4, 3, 4);
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(274, 30);
            txtUserID.TabIndex = 16;
            txtUserID.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.73684F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.52632F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 174F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.73684F));
            tableLayoutPanel1.Controls.Add(txtName, 4, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 3, 0);
            tableLayoutPanel1.Controls.Add(txtUsername, 1, 0);
            tableLayoutPanel1.Controls.Add(txtPassword, 1, 2);
            tableLayoutPanel1.Controls.Add(txtConfirmPassword, 4, 2);
            tableLayoutPanel1.Controls.Add(label6, 0, 2);
            tableLayoutPanel1.Controls.Add(label5, 3, 2);
            tableLayoutPanel1.Controls.Add(lblMilitaryNo, 0, 1);
            tableLayoutPanel1.Controls.Add(txtMilitaryNo, 1, 1);
            tableLayoutPanel1.Controls.Add(txtEmail, 4, 1);
            tableLayoutPanel1.Controls.Add(label4, 3, 1);
            tableLayoutPanel1.Location = new Point(3, 27);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.Size = new Size(952, 127);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Dock = DockStyle.Fill;
            txtName.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.Location = new Point(673, 4);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.Size = new Size(276, 28);
            txtName.TabIndex = 27;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(3, 7);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(143, 27);
            label3.TabIndex = 14;
            label3.Text = "User Name";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(499, 7);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(167, 27);
            label1.TabIndex = 16;
            label1.Text = "Name";
            // 
            // txtUsername
            // 
            txtUsername.Dock = DockStyle.Fill;
            txtUsername.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(153, 4);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(274, 30);
            txtUsername.TabIndex = 15;
            // 
            // txtPassword
            // 
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtPassword.Location = new Point(153, 88);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(274, 30);
            txtPassword.TabIndex = 26;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Dock = DockStyle.Fill;
            txtConfirmPassword.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtConfirmPassword.Location = new Point(673, 88);
            txtConfirmPassword.Margin = new Padding(3, 4, 3, 4);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(276, 30);
            txtConfirmPassword.TabIndex = 25;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(3, 91);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.Yes;
            label6.Size = new Size(143, 29);
            label6.TabIndex = 22;
            label6.Text = "Password";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(499, 92);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.Yes;
            label5.Size = new Size(167, 27);
            label5.TabIndex = 24;
            label5.Text = "Confirm Password";
            // 
            // lblMilitaryNo
            // 
            lblMilitaryNo.Anchor = AnchorStyles.None;
            lblMilitaryNo.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblMilitaryNo.Location = new Point(3, 50);
            lblMilitaryNo.Name = "lblMilitaryNo";
            lblMilitaryNo.RightToLeft = RightToLeft.Yes;
            lblMilitaryNo.Size = new Size(143, 25);
            lblMilitaryNo.TabIndex = 28;
            lblMilitaryNo.Text = "Military No (KW)";
            // 
            // txtMilitaryNo
            // 
            txtMilitaryNo.Dock = DockStyle.Fill;
            txtMilitaryNo.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtMilitaryNo.Location = new Point(153, 46);
            txtMilitaryNo.Margin = new Padding(3, 4, 3, 4);
            txtMilitaryNo.Name = "txtMilitaryNo";
            txtMilitaryNo.Size = new Size(274, 28);
            txtMilitaryNo.TabIndex = 29;
            // 
            // txtEmail
            // 
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(673, 46);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(276, 28);
            txtEmail.TabIndex = 25;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(499, 50);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(167, 25);
            label4.TabIndex = 18;
            label4.Text = "Email";
            // 
            // btnAddUser
            // 
            btnAddUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddUser.BackColor = Color.FromArgb(41, 128, 185);
            btnAddUser.FlatAppearance.BorderSize = 0;
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            btnAddUser.IconColor = Color.DarkBlue;
            btnAddUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddUser.IconSize = 30;
            btnAddUser.Location = new Point(800, 168);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(153, 47);
            btnAddUser.TabIndex = 2;
            btnAddUser.Text = "Add User";
            btnAddUser.TextAlign = ContentAlignment.MiddleRight;
            btnAddUser.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnPreviousPage
            // 
            btnPreviousPage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPreviousPage.Location = new Point(806, 13);
            btnPreviousPage.Name = "btnPreviousPage";
            btnPreviousPage.Size = new Size(52, 38);
            btnPreviousPage.TabIndex = 1;
            btnPreviousPage.Text = "<";
            btnPreviousPage.UseVisualStyleBackColor = true;
            btnPreviousPage.Click += btnPreviousPage_Click;
            // 
            // btnFirstPage
            // 
            btnFirstPage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFirstPage.Location = new Point(754, 13);
            btnFirstPage.Name = "btnFirstPage";
            btnFirstPage.Size = new Size(52, 38);
            btnFirstPage.TabIndex = 4;
            btnFirstPage.Text = "<<";
            btnFirstPage.UseVisualStyleBackColor = true;
            btnFirstPage.Click += btnFirstPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNextPage.Location = new Point(858, 13);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(52, 38);
            btnNextPage.TabIndex = 2;
            btnNextPage.Text = ">";
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnLastPage
            // 
            btnLastPage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLastPage.Location = new Point(908, 13);
            btnLastPage.Name = "btnLastPage";
            btnLastPage.Size = new Size(52, 38);
            btnLastPage.TabIndex = 3;
            btnLastPage.Text = ">>";
            btnLastPage.UseVisualStyleBackColor = true;
            btnLastPage.Click += btnLastPage_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(groupBox1);
            panel2.Location = new Point(0, 248);
            panel2.Name = "panel2";
            panel2.Size = new Size(982, 325);
            panel2.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(pnlPager);
            groupBox1.Controls.Add(dgvUsers);
            groupBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(0, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(982, 307);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "User List";
            // 
            // pnlPager
            // 
            pnlPager.Controls.Add(btnPreviousPage);
            pnlPager.Controls.Add(btnNextPage);
            pnlPager.Controls.Add(btnFirstPage);
            pnlPager.Controls.Add(btnLastPage);
            pnlPager.Dock = DockStyle.Bottom;
            pnlPager.Location = new Point(3, 246);
            pnlPager.Name = "pnlPager";
            pnlPager.Size = new Size(976, 58);
            pnlPager.TabIndex = 5;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeColumns = false;
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { SLNo, UserID, UserName, FullName, MilitaryNo, Email, Edit });
            dgvUsers.Location = new Point(3, 29);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.RowTemplate.Height = 29;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(960, 216);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellClick += dgvUsers_CellClick;
            // 
            // SLNo
            // 
            SLNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            SLNo.HeaderText = "Sl";
            SLNo.MinimumWidth = 6;
            SLNo.Name = "SLNo";
            SLNo.Width = 59;
            // 
            // UserID
            // 
            UserID.HeaderText = "User ID";
            UserID.MinimumWidth = 6;
            UserID.Name = "UserID";
            UserID.Visible = false;
            UserID.Width = 125;
            // 
            // UserName
            // 
            UserName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            UserName.HeaderText = "User Name ";
            UserName.MinimumWidth = 6;
            UserName.Name = "UserName";
            // 
            // FullName
            // 
            FullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FullName.HeaderText = "Name";
            FullName.MinimumWidth = 6;
            FullName.Name = "FullName";
            // 
            // MilitaryNo
            // 
            MilitaryNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            MilitaryNo.HeaderText = "Military No";
            MilitaryNo.MinimumWidth = 6;
            MilitaryNo.Name = "MilitaryNo";
            MilitaryNo.Width = 121;
            // 
            // Email
            // 
            Email.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.Width = 89;
            // 
            // Edit
            // 
            Edit.HeaderText = "";
            Edit.Image = Properties.Resources.edit;
            Edit.ImageLayout = DataGridViewImageCellLayout.Stretch;
            Edit.MinimumWidth = 6;
            Edit.Name = "Edit";
            Edit.Width = 60;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            errorProvider3.ContainerControl = this;
            // 
            // Users
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 573);
            Controls.Add(groupBox2);
            Controls.Add(panel2);
            Name = "Users";
            Load += Users_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            pnlPager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider2).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private GroupBox groupBox1;
        private DataGridView dgvUsers;
        private GroupBox groupBox2;
        private Label label3;
        private TextBox txtUsername;
        private Label label4;
        private Label label1;
        private Label label5;
        private Label label6;
        private FontAwesome.Sharp.IconButton btnAddUser;
        private TextBox txtName;
        private TextBox txtConfirmPassword;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtEmail;
        private ErrorProvider errorProvider1;
        private ErrorProvider errorProvider2;
        private ErrorProvider errorProvider3;
        private TextBox txtPassword;
        private Label lblMilitaryNo;
        private TextBox txtMilitaryNo;
        private TextBox txtUserID;
        private DataGridViewTextBoxColumn SLNo;
        private DataGridViewTextBoxColumn UserID;
        private DataGridViewTextBoxColumn UserName;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn MilitaryNo;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewImageColumn Edit;
        private Button btnFirstPage;
        private Button btnLastPage;
        private Button btnNextPage;
        private Button btnPreviousPage;
        private Panel panel1;
        private Panel pnlPager;
    }
}