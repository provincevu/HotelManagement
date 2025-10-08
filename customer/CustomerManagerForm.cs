using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HotelManagement
{
    public partial class CustomerManagerForm : UserControl
    {
        private string connString = "Data Source=hotel.db;Version=3;";
        private List<CustomerModel> customers = new List<CustomerModel>();
        private string[] genders = new string[] { "Nam", "Nữ", "Khác" };
        private int selectedIndex = -1;

        public CustomerManagerForm()
        {
            InitializeComponent();
            LoadGenders();
            LoadCustomers();
            SetDetailMode(false);
        }

        private void LoadGenders()
        {
            cbGender.Items.Clear();
            foreach (var g in genders)
                cbGender.Items.Add(g);
            cbGender.SelectedIndex = 0;
        }

        private void LoadCustomers(string keyword = "")
        {
            customers.Clear();
            lvCustomers.Items.Clear();
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                string sql = @"SELECT c.Name, c.Phone, s.SexName, c.Birth
                               FROM Customers c
                               LEFT JOIN Sex s ON c.SexId = s.Id";
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    sql += " WHERE c.Name LIKE @kw OR c.Phone LIKE @kw";
                }
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    if (!string.IsNullOrWhiteSpace(keyword))
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        int stt = 1;
                        while (reader.Read())
                        {
                            var model = new CustomerModel
                            {
                                Name = reader["Name"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Gender = reader["SexName"].ToString(),
                                Birth = reader["Birth"].ToString()
                            };
                            customers.Add(model);
                            var item = new ListViewItem(new string[]
                            {
                                stt.ToString(),
                                model.Name,
                                model.Phone,
                                model.Gender,
                                model.Birth
                            });
                            lvCustomers.Items.Add(item);
                            stt++;
                        }
                    }
                }
            }
        }

        private void SetDetailMode(bool enabled)
        {
            gbDetail.Enabled = enabled;
            btnSave.Enabled = enabled;
            btnCancel.Enabled = enabled;
            btnAdd.Enabled = !enabled;
            btnEdit.Enabled = !enabled && lvCustomers.SelectedItems.Count > 0;
            btnDelete.Enabled = !enabled && lvCustomers.SelectedItems.Count > 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearDetail();
            SetDetailMode(true);
            selectedIndex = -1;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvCustomers.SelectedItems.Count == 0) return;
            selectedIndex = lvCustomers.SelectedItems[0].Index;
            var cust = customers[selectedIndex];
            txtName.Text = cust.Name;
            txtPhone.Text = cust.Phone;
            cbGender.SelectedItem = string.IsNullOrEmpty(cust.Gender) ? "Nam" : cust.Gender;
            if (DateTime.TryParse(cust.Birth, out DateTime d))
                dtpBirth.Value = d;
            else
                dtpBirth.Value = DateTime.Now;
            txtPhone.Enabled = false;
            SetDetailMode(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvCustomers.SelectedItems.Count == 0) return;
            var cust = customers[lvCustomers.SelectedItems[0].Index];
            if (MessageBox.Show($"Xóa khách hàng {cust.Name} ({cust.Phone})?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var con = new SQLiteConnection(connString))
                {
                    con.Open();
                    string sql = "DELETE FROM Customers WHERE Phone=@p";
                    using (var cmd = new SQLiteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@p", cust.Phone);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadCustomers(txtSearch.Text.Trim());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCustomers(txtSearch.Text.Trim());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadCustomers();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            int sexId = cbGender.SelectedIndex + 1; // Giả sử SexId: 1-Nam,2-Nữ,3-Khác
            string birth = dtpBirth.Value.ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng nhập đủ tên và số điện thoại!");
                return;
            }
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                if (selectedIndex == -1) // Thêm mới
                {
                    string checkSql = "SELECT COUNT(*) FROM Customers WHERE Phone=@phone";
                    using (var cmd = new SQLiteCommand(checkSql, con))
                    {
                        cmd.Parameters.AddWithValue("@phone", phone);
                        long cnt = (long)cmd.ExecuteScalar();
                        if (cnt > 0)
                        {
                            MessageBox.Show("Số điện thoại đã tồn tại!");
                            return;
                        }
                    }
                    string sql = "INSERT INTO Customers(Name, Phone, SexId, Birth) VALUES(@n, @p, @s, @b)";
                    using (var cmd = new SQLiteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@n", name);
                        cmd.Parameters.AddWithValue("@p", phone);
                        cmd.Parameters.AddWithValue("@s", sexId);
                        cmd.Parameters.AddWithValue("@b", birth);
                        cmd.ExecuteNonQuery();
                    }
                }
                else // Sửa
                {
                    string sql = "UPDATE Customers SET Name=@n, SexId=@s, Birth=@b WHERE Phone=@p";
                    using (var cmd = new SQLiteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@n", name);
                        cmd.Parameters.AddWithValue("@s", sexId);
                        cmd.Parameters.AddWithValue("@b", birth);
                        cmd.Parameters.AddWithValue("@p", phone);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            LoadCustomers();
            SetDetailMode(false);
            ClearDetail();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetDetailMode(false);
            ClearDetail();
        }

        private void lvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!gbDetail.Enabled)
            {
                btnEdit.Enabled = lvCustomers.SelectedItems.Count > 0;
                btnDelete.Enabled = lvCustomers.SelectedItems.Count > 0;
            }
        }

        private void ClearDetail()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            cbGender.SelectedIndex = 0;
            dtpBirth.Value = DateTime.Now;
            txtPhone.Enabled = true;
        }
    }
}