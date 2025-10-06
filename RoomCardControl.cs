using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class RoomCardControl : UserControl
    {
        public event EventHandler EditClicked;
        public event EventHandler DeleteClicked;

        private static Dictionary<string, Color> statusColorMap = new Dictionary<string, Color>();
        private static List<Color> availableColors = new List<Color>
        {
            Color.LightSkyBlue,
            Color.LightGreen,
            Color.LightSalmon,
            Color.LightYellow,
            Color.LightPink,
            Color.LightGray,
            Color.LightCoral,
            Color.LightCyan,
            Color.LightGoldenrodYellow,
            Color.LightSteelBlue
        };
        private static Random rand = new Random();

        public RoomCardControl()
        {
            InitializeComponent();
            this.Size = new Size(200, 150);
            this.Margin = new Padding(15);
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public void SetRoomInfo(string roomName, string status, string roomType, double price)
        {
            lblRoomName.Text = "Phòng " + roomName;
            lblStatus.Text = "Trạng thái: " + status;
            lblRoomType.Text = "Loại: " + roomType;
            lblPrice.Text = "Giá: " + price.ToString("N0") + " VND";

            // Lấy màu cho trạng thái, debug giá trị status
            // MessageBox.Show($"Status: {status}");
            Color color = GetColorForStatus(status);
            this.BackColor = color;
        }

        private static Color GetColorForStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return SystemColors.Control;

            if (statusColorMap.ContainsKey(status))
                return statusColorMap[status];

            Color color;
            if (statusColorMap.Count < availableColors.Count)
                color = availableColors.First(c => !statusColorMap.Values.Contains(c));
            else
                color = availableColors[rand.Next(availableColors.Count)];
            statusColorMap[status] = color;
            return color;
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