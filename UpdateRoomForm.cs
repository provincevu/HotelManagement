using System;
using System.Data.SQLite;
using System.Windows.Forms;

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
            lblRoomInfo.Text = "Phòng: " + GetRoomNumber(roomId);
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

                // Thêm khách vào phòng (N-N)
                if (AddCustomerToRoom(RoomId, phone))
                {
                    MessageBox.Show("Đã thêm người vào phòng!");
                    LoadRoomCustomerList();
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

                // Thêm khách mới vào bảng Customers nếu chưa có
                AddOrUpdateCustomer(new CustomerModel
                {
                    Name = name,
                    Phone = phone,
                    SexId = sexId,
                    Birth = birth
                });

                // Thêm vào bảng N-N
                if (AddCustomerToRoom(RoomId, phone))
                {
                    MessageBox.Show("Đã thêm khách mới vào phòng!");
                    LoadRoomCustomerList();
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

        // Cập nhật thông tin khách (trong bảng Customers)
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
    }

    // Helper class cho ComboBox
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public ComboBoxItem(string text, object val)
        {
            Text = text;
            Value = val;
        }
        public override string ToString() { return Text; }
    }
}