//using System;
//using System.Windows.Forms;

//namespace HotelManagement
//{
//    public partial class RegisterForm : Form
//    {
//        public RegisterForm()
//        {
//            InitializeComponent();
//        }

//        private void btnRegister_Click(object sender, EventArgs e)
//        {
//            string username = txtUsername.Text.Trim();
//            string password = txtPassword.Text.Trim();
//            string confirm = txtConfirm.Text.Trim();

//            if (string.IsNullOrWhiteSpace(username) || username == "Tên đăng nhập"
//                || string.IsNullOrWhiteSpace(password) || password == "Mật khẩu"
//                || string.IsNullOrWhiteSpace(confirm) || confirm == "Nhập lại mật khẩu")
//            {
//                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
//                return;
//            }

//            if (password != confirm)
//            {
//                MessageBox.Show("Mật khẩu xác nhận không khớp!");
//                return;
//            }

//            if (DataBase.RegisterUser(username, password))
//            {
//                MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.");
//                this.Close();
//            }
//            else
//            {
//                MessageBox.Show("Tên đăng nhập đã tồn tại!");
//            }
//        }

//        // Placeholder thủ công cho .NET 4.x:
//        private void txtUsername_Enter(object sender, EventArgs e)
//        {
//            if (txtUsername.ForeColor == System.Drawing.Color.Gray)
//            {
//                txtUsername.Text = "";
//                txtUsername.ForeColor = System.Drawing.Color.Black;
//            }
//        }

//        private void txtUsername_Leave(object sender, EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(txtUsername.Text))
//            {
//                txtUsername.Text = "Tên đăng nhập";
//                txtUsername.ForeColor = System.Drawing.Color.Gray;
//            }
//        }

//        private void txtPassword_Enter(object sender, EventArgs e)
//        {
//            if (txtPassword.ForeColor == System.Drawing.Color.Gray)
//            {
//                txtPassword.Text = "";
//                txtPassword.ForeColor = System.Drawing.Color.Black;
//                txtPassword.PasswordChar = '*';
//            }
//        }


//        private void txtPassword_Leave(object sender, EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(txtPassword.Text))
//            {
//                txtPassword.Text = "Mật khẩu";
//                txtPassword.ForeColor = System.Drawing.Color.Gray;
//                txtPassword.PasswordChar = '\0';
//            }
//        }

//        private void txtConfirm_Enter(object sender, EventArgs e)
//        {
//            if (txtConfirm.ForeColor == System.Drawing.Color.Gray)
//            {
//                txtConfirm.Text = "";
//                txtConfirm.ForeColor = System.Drawing.Color.Black;
//                txtConfirm.PasswordChar = '*';
//            }
//        }

//        private void txtConfirm_Leave(object sender, EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(txtConfirm.Text))
//            {
//                txtConfirm.Text = "Nhập lại mật khẩu";
//                txtConfirm.ForeColor = System.Drawing.Color.Gray;
//                txtConfirm.PasswordChar = '\0';
//            }
//        }

//        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
//        {
//            // Chuyển sang form đăng nhập
//            this.Close();
//            LoginForm reg = new LoginForm();
//            reg.ShowDialog();
//        }
//    }
//}