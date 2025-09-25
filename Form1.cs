using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class Form1 : Form

    
    {
        private bool customerManageBtnClicked = false;
        private bool customerListBtnClicked = false;
        private Color defaultBackColor; 


        public Form1()
        {
            InitializeComponent();

            defaultBackColor = customerManagePanel.BackColor;

            // Gắn event click và paint để vẽ border cho customerManageBtn
            customerManageBtn.Click += customerManageBtn_Click;
            customerManageBtn.Paint += customerManageBtn_Paint;
            // Gắn event click và paint để vẽ border cho customerManageBtn
            customerListBtn.Click += customerListBtn_Click;
            customerListBtn.Paint += customerListBtn_Paint;
        }

        private void HideAllPanels()
        {
            customerListPanel.Visible = false;
            customerManagePanel.Visible = false;
        }

        private void customerManageBtn_Click(object sender, EventArgs e)
        {
            // Đổi màu nền của button khi được click
            customerManageBtn.BackColor = Color.LightGray;
            customerListBtn.BackColor = defaultBackColor;
            // Cập nhật trạng thái button được click
            customerManageBtnClicked = true;
            customerListBtnClicked = false;
            // Vẽ lại button để hiển thị border
            customerManageBtn.Invalidate();
            customerListBtn.Invalidate();
            // Hiển thị panel tương ứng
            HideAllPanels();
            customerManagePanel.Visible = true;
        }

        private void customerManageBtn_Paint(object sender, PaintEventArgs e)
        {
            if (customerManageBtnClicked)
            {
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, 5, customerManageBtn.Height);
                }
            }
        }

        private void customerListBtn_Paint(object sender, PaintEventArgs e)
        {
            if (customerListBtnClicked)
            {
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, 5, customerListBtn.Height);
                }
            }
        }



        private void customerListBtn_Click(object sender, EventArgs e)
        {
            // Đổi màu nền của button khi được click
            customerManageBtn.BackColor = defaultBackColor;
            customerListBtn.BackColor = Color.LightGray;
            // Cập nhật trạng thái button được click
            customerManageBtnClicked = false;
            customerListBtnClicked = true;
            // Vẽ lại button để hiển thị border
            customerManageBtn.Invalidate();
            customerListBtn.Invalidate();
            // Hiển thị panel tương ứng
            HideAllPanels();
            customerListPanel.Visible = true;
        }
    }
}
