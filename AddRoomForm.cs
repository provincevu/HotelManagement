using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class AddRoomForm : Form
    {
        public AddRoomForm()
        {
            InitializeComponent();
            LoadRoomTypes();
            LoadRoomStatuses();
        }

        private void LoadRoomTypes()
        {
            comboBoxRoomType.Items.Clear();
            var roomTypes = DataBase.GetAllRoomTypes();
            foreach (var rt in roomTypes)
            {
                comboBoxRoomType.Items.Add(new ComboBoxItem
                {
                    Text = rt["TypeName"].ToString() + $" (Giá: {rt["Price"]})",
                    Value = (int)(long)rt["Id"]
                });
            }
            if (comboBoxRoomType.Items.Count > 0)
                comboBoxRoomType.SelectedIndex = 0;
        }

        private void LoadRoomStatuses()
        {
            comboBoxStatus.Items.Clear();
            var statuses = DataBase.GetAllRoomStatuses();
            foreach (var status in statuses)
                comboBoxStatus.Items.Add(status);
            if (comboBoxStatus.Items.Count > 0)
                comboBoxStatus.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string roomNumber = txtRoomNumber.Text.Trim();
            if (string.IsNullOrEmpty(roomNumber))
            {
                MessageBox.Show("Số phòng không thể để trống!");
                return;
            }
            if (comboBoxRoomType.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn 1 loại phòng.");
                return;
            }
            if (comboBoxStatus.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái phòng.");
                return;
            }
            int roomTypeId = ((ComboBoxItem)comboBoxRoomType.SelectedItem).Value;
            string status = comboBoxStatus.SelectedItem.ToString();

            bool result = DataBase.AddRoom(roomNumber, roomTypeId, status);
            if (result)
            {
                MessageBox.Show("Thêm thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm phòng thất bại. Số phòng đã tồn tại.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void linkAddStatus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var frm = new AddRoomStatusForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadRoomStatuses();
                }
            }
        }

        private void btnAddRoomType_Click(object sender, EventArgs e)
        {
            using (var frm = new AddRoomTypeForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadRoomTypes();
                }
            }
        }

        // Helper class for ComboBoxItem
        private class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text;
        }
    }
}