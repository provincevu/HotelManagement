using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class AddRoomStatusForm : Form
    {
        public AddRoomStatusForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string status = txtStatus.Text.Trim();
            if (string.IsNullOrEmpty(status))
            {
                MessageBox.Show("không thể để tên trống!");
                return;
            }
            bool result = DataBase.AddRoomStatus(status);
            if (result)
            {
                MessageBox.Show("thêm trang thái thành công");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("không thể thêm, có vẻ tên đã tồn tại");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}