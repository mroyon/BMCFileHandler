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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            _loadUser();
        }

        private void _loadUser()
        {
            try
            {
                CancellationToken cancellationToken = new CancellationToken();
                IHttpContextAccessor httpContextAccessor = null;
                var _users = BFC.Core.FacadeCreatorObjects.Security.owin_userFCC.GetFacadeCreate(httpContextAccessor).GetDataForDropDown(

                    new BDO.Core.DataAccessObjects.SecurityModels.owin_userEntity()
                    {
                        PageSize = 10000,
                        CurrentPage = 1
                    },
                    cancellationToken).Result;

                if (_users != null && _users.Count > 0)
                {
                    dgvUsers.DataSource = _users;

                    for (int i = 0; i < dgvUsers.Columns.Count - 1; i++)
                    {
                        dgvUsers.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    dgvUsers.Columns[dgvUsers.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
