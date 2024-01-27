using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMCFileMangement.forms
{
    public partial class frmLoginForm : Form
    {
        public frmLoginForm()
        {
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
                    cancellationToken);

                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
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
