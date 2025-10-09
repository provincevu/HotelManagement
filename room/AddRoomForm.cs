using System;
using System.Collections.Generic;
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
                    Value = ParseId(rt["Id"])
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
            {
                comboBoxStatus.Items.Add(new ComboBoxItem
                {
                    Text = status.StatusName,
                    Value = status.Id
                });
            }
            if (comboBoxStatus.Items.Count > 0)
                comboBoxStatus.SelectedIndex = 0;
        }


        private int ParseId(object idObj)
        {
            if (idObj == null || idObj is DBNull) return -1;
            if (idObj is int i) return i;
            if (idObj is long l) return Convert.ToInt32(l);
            if (idObj is string s && int.TryParse(s, out int result)) return result;
            try
            {
                return Convert.ToInt32(idObj);
            }
            catch
            {
                return -1;
            }
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
            int statusId = ((ComboBoxItem)comboBoxStatus.SelectedItem).Value;

            bool result = DataBase.AddRoom(roomNumber, roomTypeId, statusId);
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

        private class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text;
        }
    }
}