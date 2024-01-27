using BMCFileMangement.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace BMCFileMangement.forms
{
    public partial class frmLogin : Form
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<frmLogin> _logger;

        private readonly IMessageService _msgService;
        private readonly IConfigurationRoot _config;

        public frmLogin(IConfigurationRoot config,
            ILoggerFactory loggerFactory,
            IMessageService msgService)
        {
            _config = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<frmLogin>();
            _msgService = msgService;
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "mroyon@gmail.com";
            txtPassword.Text = "121212";

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //var d = _httpAuthorizationService.GetAuthToken();
            //new frmMainLanding(_httpAuthorizationService, _loggerFactory).Show();
            ////this.Close();
            //this.Hide();

            // Simulate a simple login scenario
            string enteredUsername = txtUsername.Text;
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
                        username = txtUsername.Text,
                        password = txtPassword.Text
                    },
                    cancellationToken);
                if (res.Result != null)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    if (DialogResult == DialogResult.OK)
                    {
                        //new MainWindows(_config, _loggerFactory, _msgService).Show();                                                           //Application.Run(new MainWindows());
                        MainWindow mform = new MainWindow(_config, _loggerFactory, _msgService);
                        mform.Show();//Application.Run(new MainWindows());
                    }
                    this.Hide();
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Login failed!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //DialogResult = DialogResult.OK;
                    //Close();
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
        private void btnCloseApp_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Do you want to close application. Confirm?", "Close Application", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                this.Activate();
            }

        }
    }
}
