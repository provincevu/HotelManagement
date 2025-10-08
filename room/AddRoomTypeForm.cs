using System;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class AddRoomTypeForm : Form
    {
        public AddRoomTypeForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string typeName = txtTypeName.Text.Trim();
            if (string.IsNullOrEmpty(typeName))
            {
                MessageBox.Show("Loại phòng không thể để trống!");
                return;
            }
            if (!double.TryParse(txtPrice.Text.Trim(), out double price) || price < 0)
            {
                MessageBox.Show("Giá không hợp lệ");
                return;
            }
            bool result = DataBase.AddRoomType(typeName, price);
            if (result)
            {
                MessageBox.Show("Thêm loại phòng thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add room type. Maybe it already exists.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}