using BMCFileMangement.Services.Interface;
using FontAwesome.Sharp;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Services.Maps;

namespace BMCFileMangement.forms
{
    public partial class frmMainWindow : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;


        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<frmMainWindow> _logger;
        private readonly IMessageService _msgService;
        private readonly IConfigurationRoot _config;
        private readonly IApplicationLogService _applog;
        private readonly IUserProfileService _userprofile;
        private readonly IFileNotificationService _fileNotificationList;
        private readonly IFTPTransferService _fTPTransferService;


        public frmMainWindow(IConfigurationRoot config,
            ILoggerFactory loggerFactory,
            IMessageService msgService,
            IApplicationLogService applog,
            IUserProfileService userprofile,
            IFileNotificationService fileNotificationList, 
            IFTPTransferService fTPTransferService)
        {
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<frmMainWindow>();
            _msgService = msgService;
            _applog = applog;
            _fileNotificationList = fileNotificationList;
            _userprofile = userprofile;
            _fTPTransferService = fTPTransferService;


            InitializeComponent();
            InitializeComponent2();

            #region  Form Building : Tamatama
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            ////Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            #endregion

            #region form Event Handle
            ibtnNotification.Click +=  ibtnNotification_Click;
            ibtnUser.Click += ibtnUser_Click;
            ibtnDashboard.Click += ibtnDashboard_Click;
            panleTitleBar.MouseDown += panleTitleBar_MouseDown;
            btnMaximizes.Click += btnMaximizes_Click;
            btnMinimize.Click += btnMinimize_Click;
            btnClose.Click += btnClose_Click;
            #endregion
        }

        private void InitializeComponent2()
        {
            this.notificationAndDataQuerybgWorker1 = new BMCFileMangement.forms.UserControls.NotificationAndDataQueryBGWorker(
              _config,
          _loggerFactory,
          _msgService,
          _applog,
          _userprofile,
          _fileNotificationList,
          _fTPTransferService,
          this);

            this.notificationDataListViewControl1 = new BMCFileMangement.forms.UserControls.NotificationDataListViewControl(
                _config,
          _loggerFactory,
          _msgService,
          _applog,
          _userprofile,
          _fileNotificationList,
          _fTPTransferService);

            this.panleTitleBar.Controls.Add(this.notificationAndDataQuerybgWorker1);
            this.groupBox1.Controls.Add(this.notificationDataListViewControl1);
            // 
            // notificationAndDataQuerybgWorker1
            // 
            this.notificationAndDataQuerybgWorker1.Location = new System.Drawing.Point(232, 14);
            this.notificationAndDataQuerybgWorker1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.notificationAndDataQuerybgWorker1.Name = "notificationAndDataQuerybgWorker1";
            this.notificationAndDataQuerybgWorker1.Size = new System.Drawing.Size(197, 25);
            this.notificationAndDataQuerybgWorker1.TabIndex = 9;

            // 
            // notificationDataListViewControl1
            // 
            this.notificationDataListViewControl1.Location = new System.Drawing.Point(5, 21);
            this.notificationDataListViewControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.notificationDataListViewControl1.Name = "notificationDataListViewControl1";
            this.notificationDataListViewControl1.Size = new System.Drawing.Size(1051, 131);
            this.notificationDataListViewControl1.TabIndex = 0;


            ibtnNotification.Click += ibtnNotification_Click;
        }


        public void LostNotificaitonListFromExtTrigger()
        {
            this.notificationDataListViewControl1.loadDataForNotification();
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {

        }
        private void frmMainWindow_Load(object sender, EventArgs e)
        {

        }
        private void frmMainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Ensure the background worker is stopped when the form is closing
            if (notificationAndDataQuerybgWorker1.backgroundWorker != null && notificationAndDataQuerybgWorker1.backgroundWorker.IsBusy)
            {
                notificationAndDataQuerybgWorker1.backgroundWorker.CancelAsync();
            }
        }

        #region Form Building : : Tamatama
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelBody.Controls.Add(childForm);
            panelBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblChildFormTitle.Text = childForm.Text;
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblChildFormTitle.Text = "Home";
        }

        private void ibtnDashboard_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                Reset();
            }
            ActivateButton(sender, RGBColors.color1);
            //OpenChildForm(new Test1());
        }

        private void ibtnUser_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                Reset();
            }
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new Users(_config, _loggerFactory, _msgService, _applog, _userprofile));
        }

        private void ibtnNotification_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new frmFileSend(
                _config, 
                _loggerFactory, 
                _msgService, 
                _applog, 
                _userprofile, 
                _fileNotificationList,
                _fTPTransferService));
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panleTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnHomeLogo_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                Reset();
            };
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            //if (WindowState == FormWindowState.Normal)
            //    WindowState = FormWindowState.Maximized;
            //else
            WindowState = FormWindowState.Minimized;
        }

        //private void btnMaximize_Click(object sender, EventArgs e)
        //{
        //    WindowState = FormWindowState.Minimized;
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizes_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
        #endregion
    }
}
