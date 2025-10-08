using System;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class InvoiceForm : Form
    {
        public InvoiceForm()
        {
            InitializeComponent();
        }

        public void ShowInvoice(InvoiceModel invoice)
        {
            txtId.Text = invoice.Id.ToString();
            // Lấy tên phòng
            string roomNumber = DataBase.GetRoomNumber(invoice.RoomId);
            txtRoomId.Text = roomNumber;
            txtStaffCheckOut.Text = invoice.StaffCheckOut;
            txtCustomerCheckOut.Text = invoice.CustomerCheckOut;
            txtTotalPrice.Text = invoice.TotalPrice.ToString("N0");
            txtCheckInDate.Text = invoice.CheckInDate;
            txtCheckOutDate.Text = invoice.CheckOutDate;
            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Đánh dấu xác nhận
            this.Close();
        }
    }
}