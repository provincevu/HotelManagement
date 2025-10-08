using System;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class TestRoomCardForm : Form
    {
        public TestRoomCardForm()
        {
            this.Text = "Test RoomCardControl Color";
            this.Size = new System.Drawing.Size(700, 300);

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Fill;
            this.Controls.Add(panel);

            string[] testStatuses = { "Trống", "Đang ở", "Đang bảo trì", "Trống", "Đang ở", "Unknown", "" };

            for (int i = 0; i < testStatuses.Length; i++)
            {
                var card = new RoomCardControl();
                card.SetRoomInfo((100 + i).ToString(), testStatuses[i], "Phòng đơn", 123456 + i * 100);
                panel.Controls.Add(card);
            }
        }
    }
}