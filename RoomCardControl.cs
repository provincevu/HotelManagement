using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class RoomCardControl : UserControl
    {
        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;

        public RoomCardControl()
        {
            InitializeComponent();
            this.Size = new Size(200, 120);
            this.Margin = new Padding(15);
        }

        // Sửa lại: nhận 4 tham số
        public void SetRoomInfo(string roomName, string status, string roomType, double price)
        {
            lblRoomName.Text = roomName;
            lblStatus.Text = "Trạng thái: " + status;
            lblRoomType.Text = "Loại: " + roomType;
            lblPrice.Text = "Giá: " + price.ToString("N0") + " VND";

            // Đổi màu theo trạng thái
            switch (status)
            {
                case "Trống":
                    this.BackColor = Color.LightSkyBlue;
                    break;
                case "Đang ở":
                    this.BackColor = Color.LightGreen;
                    break;
                case "Bảo trì":
                    this.BackColor = Color.LightSalmon;
                    break;
                default:
                    this.BackColor = SystemColors.Control;
                    break;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}