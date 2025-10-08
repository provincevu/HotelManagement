using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class BaseForm : Form
    {
        // Biến lưu menu đang chọn
        private ToolStripMenuItem selectedMenuItem = null;
        private string userName; // Lưu userName để kiểm tra quyền

        public BaseForm(string username)
        {
            InitializeComponent();
            DataBase.InitializeDatabase();

            userName = username;

            // Gán custom renderer cho MenuStrip để đổi màu, font menu động
            menuStrip1.Renderer = new MyMenuRenderer(() => selectedMenuItem);

            // Gán sự kiện Click cho từng menu item
            roomManageMenuItem.Click += MenuItem_Click;
            customerMenu.Click += MenuItem_Click;
            staffMenu.Click += MenuItem_Click;
            invoiceMenu.Click += MenuItem_Click;
            dashboardMenu.Click += MenuItem_Click;

            // Mặc định chọn menu "Quản lý phòng"
            selectedMenuItem = roomManageMenuItem;
            menuStrip1.Invalidate();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Size = new Size(1250, 648);

            // Hiển thị Rooms lần đầu khi vào form
            ShowUserControl(new Rooms());

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

        /// <summary>
        /// Hiển thị UserControl lên Panel2 của splitContainer1
        /// </summary>
        private void ShowUserControl(UserControl control)
        {
            control.Dock = DockStyle.Fill; // Đặt trước khi add
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(control);
            control.BringToFront();
        }

        // Xử lý khi click menu: đổi menu được chọn và refresh lại menu + show UC
        private void MenuItem_Click(object sender, EventArgs e)
        {
            selectedMenuItem = sender as ToolStripMenuItem;
            menuStrip1.Invalidate(); // Vẽ lại menu để cập nhật màu

            if (selectedMenuItem == roomManageMenuItem)
                ShowUserControl(new Rooms());
            else if (selectedMenuItem == customerMenu)
                ShowUserControl(new CustomerManagerForm());
            else if (selectedMenuItem == staffMenu)
            {
                // Chặn truy cập nếu không phải super admin
                if (!DataBase.IsSuperAdmin(userName))
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng quản lý nhân sự!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Chọn lại menu cũ (ví dụ về lại phòng hoặc dashboard)
                    selectedMenuItem = roomManageMenuItem;
                    menuStrip1.Invalidate();
                    ShowUserControl(new Rooms());
                }
                else
                {
                    ShowUserControl(new StaffManagerForm());
                }
            }
            else if (selectedMenuItem == invoiceMenu)
                ShowUserControl(new InvoiceManagerForm());
            //else if (selectedMenuItem == dashboardMenu)
            //    ShowUserControl(new Dashboard());
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new LoginForm();
            login.Show();
            this.Dispose();
        }
    }

    // Custom Renderer cho MenuStrip
    public class MyMenuRenderer : ToolStripProfessionalRenderer
    {
        private readonly Func<ToolStripMenuItem> getSelectedMenuItem;

        public MyMenuRenderer(Func<ToolStripMenuItem> getSelectedMenuItem)
        {
            this.getSelectedMenuItem = getSelectedMenuItem;
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var menuItem = e.Item as ToolStripMenuItem;
            bool isSelected = (menuItem != null && menuItem == getSelectedMenuItem());

            if (isSelected)
                e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Item.ContentRectangle);
            else
                base.OnRenderMenuItemBackground(e);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            var menuItem = e.Item as ToolStripMenuItem;
            bool isSelected = (menuItem != null && menuItem == getSelectedMenuItem());

            // Chọn font và màu chữ
            Color textColor = isSelected ? Color.White : Color.RoyalBlue;
            Font font = isSelected
                ? new Font(e.TextFont, FontStyle.Bold)
                : new Font(e.TextFont, FontStyle.Regular);

            // Vẽ text
            TextRenderer.DrawText(
                e.Graphics,
                e.Text,
                font,
                e.TextRectangle,
                textColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );
        }
    }
}