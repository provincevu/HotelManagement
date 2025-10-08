using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Collections.Generic;

namespace HotelManagement
{
    public partial class UpdateRoomForm : Form
    {
        private string connString = "Data Source=hotel.db;Version=3;";
        private int RoomId;

        public UpdateRoomForm(int roomId)
        {
            InitializeComponent();
            this.RoomId = roomId;
            rbExistingPerson.Checked = true;
            cbExistingPerson.Enabled = true;
            pnlNewPerson.Enabled = false;
            LoadExistingPersons();
            LoadRoomCustomerList();
            LoadRoomStatuses();
            lblRoomInfo.Text = "Phòng: " + GetRoomNumber(roomId);

            // Khi mở form, cập nhật trạng thái phòng
            AutoUpdateRoomStatus(RoomId);
        }

        // Lấy số phòng từ RoomId
        private string GetRoomNumber(int roomId)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                string sql = "SELECT RoomNumber FROM Rooms WHERE Id=@id";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", roomId);
                    var result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : "";
                }
            }
        }

        // Hiển thị danh sách khách hiện tại của phòng
        private void LoadRoomCustomerList()
        {
            lvCustomers.Items.Clear();
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                string sql = @"
                    SELECT c.Name, c.Phone, s.SexName, c.Birth
                    FROM RoomCustomers rc
                    JOIN Customers c ON rc.CustomerPhone = c.Phone
                    LEFT JOIN Sex s ON c.SexId = s.Id
                    WHERE rc.RoomId = @rid";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@rid", RoomId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new ListViewItem(new string[] {
                                reader["Name"].ToString(),
                                reader["Phone"].ToString(),
                                reader["SexName"].ToString(),
                                reader["Birth"].ToString()
                            });
                            lvCustomers.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void LoadExistingPersons()
        {
            cbExistingPerson.Items.Clear();
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                string sql = "SELECT Name, Phone FROM Customers";
                using (var cmd = new SQLiteCommand(sql, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string display = $"{reader["Name"]} ({reader["Phone"]})";
                        cbExistingPerson.Items.Add(new ComboBoxItem(display, reader["Phone"].ToString()));
                    }
                }
            }
            if (cbExistingPerson.Items.Count > 0) cbExistingPerson.SelectedIndex = 0;
        }

        // Hiển thị trạng thái phòng và cho phép chuyển trạng thái
        private void LoadRoomStatuses()
        {
            cbStatusurf.Items.Clear();
            var statuses = DataBase.GetAllRoomStatuses();
            foreach (var status in statuses)
            {
                cbStatusurf.Items.Add(new ComboBoxItem(status.StatusName, status.Id));
            }
            if (cbStatusurf.Items.Count > 0)
            {
                cbStatusurf.SelectedIndex = 0;
                int currentStatusId = GetCurrentRoomStatusId();
                foreach (ComboBoxItem item in cbStatusurf.Items)
                {
                    if ((int)item.Value == currentStatusId)
                    {
                        cbStatusurf.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private int GetCurrentRoomStatusId()
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                string sql = "SELECT StatusId FROM Rooms WHERE Id=@id";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", RoomId);
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        private void btnChangeStatusupdate_Click(object sender, EventArgs e)
        {
            if (cbStatusurf.SelectedItem == null)
            {
                MessageBox.Show("Chọn trạng thái phòng!");
                return;
            }
            int statusId = (int)((ComboBoxItem)cbStatusurf.SelectedItem).Value;
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                string sql = "UPDATE Rooms SET StatusId=@sid WHERE Id=@id";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@sid", statusId);
                    cmd.Parameters.AddWithValue("@id", RoomId);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Đã cập nhật trạng thái phòng!");
        }

        private void rbExistingPerson_CheckedChanged(object sender, EventArgs e)
        {
            cbExistingPerson.Enabled = rbExistingPerson.Checked;
            pnlNewPerson.Enabled = rbNewPerson.Checked;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rbExistingPerson.Checked)
            {
                ComboBoxItem personItem = cbExistingPerson.SelectedItem as ComboBoxItem;
                if (personItem == null)
                {
                    MessageBox.Show("Vui lòng chọn người có sẵn!");
                    return;
                }
                string phone = personItem.Value.ToString();

                if (AddCustomerToRoom(RoomId, phone))
                {
                    MessageBox.Show("Đã thêm người vào phòng!");
                    LoadRoomCustomerList();
                    AutoUpdateRoomStatus(RoomId);
                }
                else
                {
                    MessageBox.Show("Khách này đã ở phòng này!");
                }
            }
            else if (rbNewPerson.Checked)
            {
                string name = txtName.Text.Trim();
                string phone = txtPhone.Text.Trim();
                int sexId = rbMale.Checked ? 1 : rbFemale.Checked ? 2 : 3;
                string birth = dtpDob.Value.ToString("yyyy-MM-dd");

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone))
                {
                    MessageBox.Show("Vui lòng nhập đủ tên và số điện thoại!");
                    return;
                }

                AddOrUpdateCustomer(new CustomerModel
                {
                    Name = name,
                    Phone = phone,
                    SexId = sexId,
                    Birth = birth
                });

                if (AddCustomerToRoom(RoomId, phone))
                {
                    MessageBox.Show("Đã thêm khách mới vào phòng!");
                    LoadRoomCustomerList();
                    AutoUpdateRoomStatus(RoomId);
                }
                else
                {
                    MessageBox.Show("Khách này đã ở phòng này!");
                }
            }
        }

        private void btnRemoveCustomer_Click(object sender, EventArgs e)
        {
            if (lvCustomers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chọn khách cần xóa khỏi phòng!");
                return;
            }
            string phone = lvCustomers.SelectedItems[0].SubItems[1].Text;
            if (RemoveCustomerFromRoom(RoomId, phone))
            {
                MessageBox.Show("Đã xóa khách khỏi phòng!");
                LoadRoomCustomerList();

                // Sau khi xóa, kiểm tra số khách còn lại
                int count = GetRoomCustomerCount(RoomId);
                if (count == 0)
                {
                    // Nếu không còn ai, cập nhật trạng thái về "trống"
                    SetRoomStatusByName(RoomId, "trống");

                    // --- Điền thông tin hóa đơn ---
                    // Lấy staff đang đăng nhập (ví dụ)
                    string staffCheckOut = "admin"; // Thay bằng biến thực tế (CurrentStaffUserName)
                                                    // Customer cuối cùng rời phòng
                    string customerCheckOut = phone;
                    // Lấy hóa đơn hiện tại
                    var invoice = DataBase.GetInvoiceByRoomId(RoomId);
                    double totalPrice = 0;
                    string checkOutDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    if (invoice != null)
                    {
                        double price = DataBase.GetRoomPrice(RoomId);
                        DateTime checkIn;
                        if (DateTime.TryParse(invoice.CheckInDate, out checkIn))
                        {
                            DateTime checkOut = DateTime.Now;
                            // Tính số giờ, chỉ cần dư 1 giây cũng lên 1 giờ
                            double totalHours = Math.Ceiling((checkOut - checkIn).TotalHours);
                            totalPrice = price * totalHours;
                            totalPrice = Math.Round(totalPrice, 0); 
                        }
                        else
                        {
                            totalPrice = 0;
                        }
                    }

                    // Sửa thông tin hóa đơn
                    DataBase.UpdateInvoiceByRoomId(RoomId, staffCheckOut, customerCheckOut, totalPrice, checkOutDate);

                    // Hiện form xác nhận hóa đơn
                    ShowInvoiceForm();
                }
                else
                {
                    // Nếu còn khách, cập nhật trạng thái về "đang ở"
                    SetRoomStatusByName(RoomId, "đang ở");
                }
            }
            else
            {
                MessageBox.Show("Không thể xóa khách!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Thêm khách vào phòng (RoomCustomers)
        private bool AddCustomerToRoom(int roomId, string customerPhone)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                // Kiểm tra số khách hiện tại trong phòng
                string countSql = "SELECT COUNT(*) FROM RoomCustomers WHERE RoomId=@rid";
                int customerCount;
                using (var cmdCount = new SQLiteCommand(countSql, con))
                {
                    cmdCount.Parameters.AddWithValue("@rid", roomId);
                    customerCount = Convert.ToInt32(cmdCount.ExecuteScalar());
                }

                // Nếu là khách đầu tiên thì tạo hóa đơn
                if (customerCount == 0)
                {
                    DataBase.AddInvoice(roomId, DateTime.Now);
                }

                // Kiểm tra trùng khách
                string checkSql = "SELECT COUNT(*) FROM RoomCustomers WHERE RoomId=@rid AND CustomerPhone=@cphone";
                using (var cmd = new SQLiteCommand(checkSql, con))
                {
                    cmd.Parameters.AddWithValue("@rid", roomId);
                    cmd.Parameters.AddWithValue("@cphone", customerPhone);
                    long cnt = (long)cmd.ExecuteScalar();
                    if (cnt > 0) return false;
                }
                string sql = "INSERT INTO RoomCustomers(RoomId, CustomerPhone) VALUES(@rid, @cphone)";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@rid", roomId);
                    cmd.Parameters.AddWithValue("@cphone", customerPhone);
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        // Xóa khách khỏi phòng
        private bool RemoveCustomerFromRoom(int roomId, string customerPhone)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                string sql = "DELETE FROM RoomCustomers WHERE RoomId=@rid AND CustomerPhone=@cphone";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@rid", roomId);
                    cmd.Parameters.AddWithValue("@cphone", customerPhone);
                    int affected = cmd.ExecuteNonQuery();
                    return affected > 0;
                }
            }
        }

        // Lấy số khách hiện tại trong phòng
        private int GetRoomCustomerCount(int roomId)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                string sql = "SELECT COUNT(*) FROM RoomCustomers WHERE RoomId=@rid";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@rid", roomId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // Đặt trạng thái phòng theo tên StatusName
        private void SetRoomStatusByName(int roomId, string statusName)
        {
            int statusId = GetStatusIdByName(statusName);
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                string sql = "UPDATE Rooms SET StatusId=@sid WHERE Id=@rid";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@sid", statusId);
                    cmd.Parameters.AddWithValue("@rid", roomId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Hiển thị bảng hóa đơn (chỉ mở form, bạn thay bằng logic thực tế của bạn)
        private void ShowInvoiceForm()
        {
            // Lấy hóa đơn cho phòng này
            var invoice = DataBase.GetInvoiceByRoomId(RoomId);
            if (invoice != null)
            {
                var frm = new InvoiceForm();
                frm.ShowInvoice(invoice); 
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn cho phòng này!");
            }
        }

        // Cập nhật trạng thái phòng tự động khi thêm khách
        private void AutoUpdateRoomStatus(int roomId)
        {
            int customerCount = GetRoomCustomerCount(roomId);

            if (customerCount > 0)
                SetRoomStatusByName(roomId, "đang ở");
            else
                SetRoomStatusByName(roomId, "trống");
        }

        // Hàm lấy Id trạng thái từ tên
        private int GetStatusIdByName(string statusName)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                string sql = "SELECT Id FROM RoomStatuses WHERE StatusName=@name";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@name", statusName);
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        private void AddOrUpdateCustomer(CustomerModel customer)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                string checkSql = "SELECT COUNT(*) FROM Customers WHERE Phone=@phone";
                bool exists;
                using (var cmd = new SQLiteCommand(checkSql, con))
                {
                    cmd.Parameters.AddWithValue("@phone", customer.Phone);
                    exists = ((long)cmd.ExecuteScalar()) > 0;
                }
                if (exists)
                {
                    string sql = "UPDATE Customers SET Name=@name, Birth=@birth, SexId=@sexId WHERE Phone=@phone";
                    using (var cmd = new SQLiteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@name", customer.Name);
                        cmd.Parameters.AddWithValue("@birth", customer.Birth);
                        cmd.Parameters.AddWithValue("@sexId", customer.SexId);
                        cmd.Parameters.AddWithValue("@phone", customer.Phone);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string sql = "INSERT INTO Customers(Name, Birth, SexId, Phone) VALUES(@name, @birth, @sexId, @phone)";
                    using (var cmd = new SQLiteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@name", customer.Name);
                        cmd.Parameters.AddWithValue("@birth", customer.Birth);
                        cmd.Parameters.AddWithValue("@sexId", customer.SexId);
                        cmd.Parameters.AddWithValue("@phone", customer.Phone);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Helper class cho ComboBox
        private class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public ComboBoxItem(string text, object value)
            {
                Text = text;
                Value = value;
            }
            public override string ToString() => Text;
        }
    }
}