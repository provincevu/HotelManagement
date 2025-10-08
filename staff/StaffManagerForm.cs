using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class StaffManagerForm : UserControl
    {
        private string connString = "Data Source=hotel.db;Version=3;";
        private List<StaffModel> staffList = new List<StaffModel>();
        private List<RoleModel> roleList = new List<RoleModel>();
        private int selectedIndex = -1;

        public StaffManagerForm()
        {
            InitializeComponent();
            LoadRoles();
            LoadStaff();
            SetDetailMode(false);
        }

        private void LoadRoles()
        {
            cbRole.Items.Clear();
            roleList.Clear();
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                string sql = "SELECT RoleId, RoleName FROM Roles";
                using (var cmd = new SQLiteCommand(sql, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var role = new RoleModel
                        {
                            RoleId = Convert.ToInt32(reader["RoleId"]),
                            RoleName = reader["RoleName"].ToString()
                        };
                        roleList.Add(role);
                        cbRole.Items.Add(role.RoleName);
                    }
                }
            }
            if (cbRole.Items.Count > 0) cbRole.SelectedIndex = 0;
        }

        private void LoadStaff(string keyword = "")
        {
            staffList.Clear();
            lvStaff.Items.Clear();
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                string sql = @"SELECT s.UserName, s.Name, s.Phone, s.IdentityNumber, r.RoleName 
                               FROM Staff s JOIN Roles r ON s.RoleId = r.RoleId";
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    sql += " WHERE s.Name LIKE @kw OR s.UserName LIKE @kw OR s.Phone LIKE @kw";
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
                            var model = new StaffModel
                            {
                                UserName = reader["UserName"].ToString(),
                                Name = reader["Name"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                IdentityNumber = reader["IdentityNumber"].ToString(),
                                RoleName = reader["RoleName"].ToString()
                            };
                            staffList.Add(model);
                            var item = new ListViewItem(new string[]
                            {
                                stt.ToString(),
                                model.UserName,
                                model.Name,
                                model.Phone,
                                model.IdentityNumber,
                                model.RoleName
                            });
                            lvStaff.Items.Add(item);
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
            btnEdit.Enabled = !enabled && lvStaff.SelectedItems.Count > 0;
            btnDelete.Enabled = !enabled && lvStaff.SelectedItems.Count > 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearDetail();
            SetDetailMode(true);
            selectedIndex = -1;
            txtUserName.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvStaff.SelectedItems.Count == 0) return;
            selectedIndex = lvStaff.SelectedItems[0].Index;
            var staff = staffList[selectedIndex];
            txtUserName.Text = staff.UserName;
            txtName.Text = staff.Name;
            txtPhone.Text = staff.Phone;
            txtIdentityNumber.Text = staff.IdentityNumber;
            cbRole.SelectedItem = staff.RoleName;
            txtPassword.Text = "";
            txtUserName.Enabled = false;
            SetDetailMode(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvStaff.SelectedItems.Count == 0) return;
            var staff = staffList[lvStaff.SelectedItems[0].Index];
            if (MessageBox.Show($"Xóa nhân viên {staff.Name} ({staff.UserName})?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var con = new SQLiteConnection(connString))
                {
                    con.Open();
                    string sql = "DELETE FROM Staff WHERE UserName=@u";
                    using (var cmd = new SQLiteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@u", staff.UserName);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadStaff(txtSearch.Text.Trim());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStaff(txtSearch.Text.Trim());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadStaff();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string idNum = txtIdentityNumber.Text.Trim();
            int roleId = -1;
            if (cbRole.SelectedIndex >= 0)
                roleId = roleList[cbRole.SelectedIndex].RoleId;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập đủ tên đăng nhập và tên nhân viên!");
                return;
            }
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                if (selectedIndex == -1) // Thêm mới
                {
                    string checkSql = "SELECT COUNT(*) FROM Staff WHERE UserName=@u";
                    using (var cmd = new SQLiteCommand(checkSql, con))
                    {
                        cmd.Parameters.AddWithValue("@u", userName);
                        long cnt = (long)cmd.ExecuteScalar();
                        if (cnt > 0)
                        {
                            MessageBox.Show("Tên đăng nhập đã tồn tại!");
                            return;
                        }
                    }
                    string sql = @"INSERT INTO Staff(UserName, PassWord, Name, IdentityNumber, Phone, RoleId)
                                   VALUES(@u, @p, @n, @id, @ph, @role)";
                    using (var cmd = new SQLiteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@u", userName);
                        cmd.Parameters.AddWithValue("@p", string.IsNullOrEmpty(password) ? userName : password);
                        cmd.Parameters.AddWithValue("@n", name);
                        cmd.Parameters.AddWithValue("@id", idNum);
                        cmd.Parameters.AddWithValue("@ph", phone);
                        cmd.Parameters.AddWithValue("@role", roleId);
                        cmd.ExecuteNonQuery();
                    }
                }
                else // Sửa
                {
                    string sql = @"UPDATE Staff SET Name=@n, IdentityNumber=@id, Phone=@ph, RoleId=@role
                                   WHERE UserName=@u";
                    if (!string.IsNullOrEmpty(password))
                    {
                        sql = @"UPDATE Staff SET Name=@n, IdentityNumber=@id, Phone=@ph, RoleId=@role, PassWord=@p
                                WHERE UserName=@u";
                    }
                    using (var cmd = new SQLiteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@n", name);
                        cmd.Parameters.AddWithValue("@id", idNum);
                        cmd.Parameters.AddWithValue("@ph", phone);
                        cmd.Parameters.AddWithValue("@role", roleId);
                        cmd.Parameters.AddWithValue("@u", userName);
                        if (!string.IsNullOrEmpty(password))
                            cmd.Parameters.AddWithValue("@p", password);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            LoadStaff();
            SetDetailMode(false);
            ClearDetail();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetDetailMode(false);
            ClearDetail();
        }

        private void linkAddRole_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var frm = new AddRoleForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string newRole = frm.NewRoleName;
                    using (var con = new SQLiteConnection(connString))
                    {
                        con.Open();
                        string checkSql = "SELECT COUNT(*) FROM Roles WHERE RoleName=@name";
                        using (var cmd = new SQLiteCommand(checkSql, con))
                        {
                            cmd.Parameters.AddWithValue("@name", newRole);
                            long cnt = (long)cmd.ExecuteScalar();
                            if (cnt > 0)
                            {
                                MessageBox.Show("Vai trò đã tồn tại!");
                                return;
                            }
                        }
                        string insertSql = "INSERT INTO Roles(RoleName) VALUES(@name)";
                        using (var cmd = new SQLiteCommand(insertSql, con))
                        {
                            cmd.Parameters.AddWithValue("@name", newRole);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Đã thêm vai trò mới!");
                    }
                    LoadRoles();
                }
            }
        }

        private void lvStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!gbDetail.Enabled)
            {
                btnEdit.Enabled = lvStaff.SelectedItems.Count > 0;
                btnDelete.Enabled = lvStaff.SelectedItems.Count > 0;
            }
        }

        private void ClearDetail()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtIdentityNumber.Text = "";
            cbRole.SelectedIndex = 0;
            txtUserName.Enabled = true;
        }
    }

    public class StaffModel
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string IdentityNumber { get; set; }
        public string RoleName { get; set; }
    }

    public class RoleModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}