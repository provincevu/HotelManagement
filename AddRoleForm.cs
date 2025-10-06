using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class AddRoleForm : Form
    {
        public string NewRoleName { get; private set; }

        public AddRoleForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string roleName = txtRoleName.Text.Trim();
            if (string.IsNullOrEmpty(roleName))
            {
                MessageBox.Show("Vui lòng nhập tên vai trò!");
                return;
            }
            NewRoleName = roleName;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}