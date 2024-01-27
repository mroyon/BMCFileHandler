using BMCFileMangement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Services.Maps;

namespace BMCFileMangement.forms
{
    public partial class frmLoginForm : Form
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<frmLoginForm> _logger;
        private readonly IMessageService _msgService;
        private readonly IConfigurationRoot _config;
        private readonly IApplicationLogService _applog;

        public frmLoginForm(
             IConfigurationRoot config,
            ILoggerFactory loggerFactory,
            IMessageService msgService,
            IApplicationLogService applog
            )
        {
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<frmLoginForm>();
            _applog = applog;
            _msgService = msgService;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Simulate a simple login scenario
            string enteredUsername = txtUserName.Text;
            string enteredPassword = txtPassword.Text;

            // Replace this with your actual login logic
            if (IsValidLogin(enteredUsername, enteredPassword))
            {
                CancellationToken cancellationToken = new CancellationToken();
                IHttpContextAccessor httpContextAccessor = null;
                var res = BFC.Core.FacadeCreatorObjects.Security.ExtendedPartial.
                    FCCKAFUserSecurity.GetFacadeCreate(httpContextAccessor).UserSignInAsync(
                    new BDO.Core.DataAccessObjects.SecurityModels.owin_userEntity()
                    {
                        username = txtUserName.Text,
                        password = txtPassword.Text
                    },
                    cancellationToken);;
                if (res.Result != null)
                {
                    _applog.SetLog("Login Successful: User: "+txtUserName.Text );
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    // Check login result
                    this.Dispose();
                }
                else {
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValidLogin(string username, string password)
        {
            // Replace this with your actual authentication logic
            // For simplicity, this example accepts any non-empty username and password
            return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);
        }

    }
}
