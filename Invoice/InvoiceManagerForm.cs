using System;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class InvoiceManagerForm : UserControl
    {
        public InvoiceManagerForm()
        {
            InitializeComponent();
            LoadInvoices();
        }

        private void LoadInvoices()
        {
            dgvInvoices.Rows.Clear();
            dgvInvoices.Columns.Clear();

            // Đảm bảo thứ tự cột khớp với thứ tự truyền vào Rows.Add
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
                dgvInvoices.Rows.Add(
                    invoice.ContainsKey("Id") ? invoice["Id"] : "",
                    invoice.ContainsKey("RoomNumber") ? invoice["RoomNumber"] :
                        (invoice.ContainsKey("RoomId") ? invoice["RoomId"] : ""),
                    invoice.ContainsKey("StaffCheckOut") ? invoice["StaffCheckOut"] : "",
                    invoice.ContainsKey("CustomerCheckOut") ? invoice["CustomerCheckOut"] :
                        (invoice.ContainsKey("CustomerPhone") ? invoice["CustomerPhone"] : ""),
                    invoice.ContainsKey("TotalPrice") ? invoice["TotalPrice"] :
                        (invoice.ContainsKey("TotalAmount") ? invoice["TotalAmount"] : ""),
                    invoice.ContainsKey("CheckInDate") ? invoice["CheckInDate"] : "",
                    invoice.ContainsKey("CheckOutDate") ? invoice["CheckOutDate"] : ""
                );
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