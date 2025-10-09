using System;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class InvoiceManagerForm : UserControl
    {
        private DateTime filterFrom;
        private DateTime filterTo;

        public InvoiceManagerForm()
        {
            InitializeComponent();

            // Giá trị mặc định cho bộ lọc là 1 tháng trước đến hôm nay
            filterFrom = DateTime.Today.AddMonths(-1);
            filterTo = DateTime.Today;

            dtpFrom.Value = filterFrom;
            dtpTo.Value = filterTo;

            LoadInvoices();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            filterFrom = dtpFrom.Value.Date;
            filterTo = dtpTo.Value.Date;
            LoadInvoices();
        }

        private void LoadInvoices()
        {
            dgvInvoices.Rows.Clear();
            dgvInvoices.Columns.Clear();

            dgvInvoices.Columns.Add("Id", "Mã hóa đơn");
            dgvInvoices.Columns.Add("Room", "Phòng");
            dgvInvoices.Columns.Add("Staff", "Nhân viên");
            dgvInvoices.Columns.Add("Customer", "Sđt khách");
            dgvInvoices.Columns.Add("Total", "Tổng tiền");
            dgvInvoices.Columns.Add("CheckIn", "Ngày nhận");
            dgvInvoices.Columns.Add("CheckOut", "Ngày trả");

            var invoices = DataBase.GetAllInvoices();
            foreach (var invoice in invoices)
            {
                // Lọc theo ngày nhận phòng (CheckInDate)
                string checkInStr = invoice.ContainsKey("CheckInDate") ? invoice["CheckInDate"]?.ToString() : "";
                DateTime checkIn;
                bool validDate = DateTime.TryParse(checkInStr, out checkIn);

                // Nếu CheckIn hợp lệ và nằm trong khoảng lọc thì hiển thị
                if (validDate && checkIn.Date >= filterFrom && checkIn.Date <= filterTo)
                {
                    dgvInvoices.Rows.Add(
                        invoice.ContainsKey("Id") ? invoice["Id"] : "",
                        invoice.ContainsKey("RoomNumber") ? invoice["RoomNumber"] :
                            (invoice.ContainsKey("RoomId") ? invoice["RoomId"] : ""),
                        invoice.ContainsKey("StaffCheckOut") ? invoice["StaffCheckOut"] : "",
                        invoice.ContainsKey("CustomerCheckOut") ? invoice["CustomerCheckOut"] :
                            (invoice.ContainsKey("CustomerPhone") ? invoice["CustomerPhone"] : ""),
                        invoice.ContainsKey("TotalPrice") ? invoice["TotalPrice"] :
                            (invoice.ContainsKey("TotalAmount") ? invoice["TotalAmount"] : ""),
                        checkInStr,
                        invoice.ContainsKey("CheckOutDate") ? invoice["CheckOutDate"] : ""
                    );
                }
            }
            dgvInvoices.ReadOnly = true;
        }

        private void dgvInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvInvoices.Rows[e.RowIndex];

            txtId.Text = row.Cells["Id"].Value?.ToString();
            txtRoom.Text = row.Cells["Room"].Value?.ToString();
            txtStaff.Text = row.Cells["Staff"].Value?.ToString();
            txtCustomer.Text = row.Cells["Customer"].Value?.ToString();
            txtTotal.Text = row.Cells["Total"].Value?.ToString();
            txtIn.Text = row.Cells["CheckIn"].Value?.ToString();
            txtOut.Text = row.Cells["CheckOut"].Value?.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent?.Controls.Remove(this);
        }
    }
}