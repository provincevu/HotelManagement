using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class BaseForm : Form
    {
        public BaseForm(string username)
        {
            InitializeComponent();
            DataBase.InitializeDatabase();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Size = new Size(1250, 648);

            // Hiển thị Rooms lần đầu khi vào form
            showRooms();

            userNameLabel.Text = "Xin chào, " + username;
            timeLabel.Text = "Hôm nay: " + DateTime.Now.ToString("dd / MM / yyyy") + "  |  " + DateTime.Now.ToString("HH : mm : ss");

            timer1.Interval = 1000; // 1 giây
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = "Hôm nay: " + DateTime.Now.ToString("dd / MM / yyyy") + "  |  " + DateTime.Now.ToString("HH : mm : ss");
        }

        private void showRooms()
        {
            splitContainer1.Panel2.Controls.Clear();
            var roomsUC = new Rooms();
            roomsUC.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(roomsUC);
        }
    }
}