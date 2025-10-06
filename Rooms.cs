using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class Rooms : UserControl
    {
        private List<RoomModel> allRooms = new List<RoomModel>();

        public Rooms()
        {
            InitializeComponent();
            LoadRoomsFromDatabase();
        }

        private void LoadRoomsFromDatabase()
        {
            allRooms.Clear();
            // Lấy danh sách phòng với đầy đủ thông tin loại phòng và trạng thái
            var roomDicts = DataBase.GetAllRooms(); // hàm này phải JOIN RoomTypes và RoomStatuses
            foreach (var dict in roomDicts)
            {
                allRooms.Add(new RoomModel
                {
                    Id = GetIntValue(dict, "Id"),
                    Name = GetStringValue(dict, "RoomNumber"),
                    Status = dict.ContainsKey("StatusName") ? GetStringValue(dict, "StatusName") : GetStringValue(dict, "Status"),
                    RoomType = GetStringValue(dict, "TypeName"),
                    Price = GetDoubleValue(dict, "Price")
                });
            }
            RenderRooms(allRooms);
        }

        private void RenderRooms(IEnumerable<RoomModel> rooms)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var room in rooms)
            {
                RoomCardControl card = new RoomCardControl();
                card.Margin = new Padding(15);
                card.SetRoomInfo(room.Name, room.Status, room.RoomType, room.Price);
                card.EditClicked += (s, e) =>
                {
                    // Xử lý sửa phòng (ví dụ mở dialog sửa, cập nhật CSDL và reload)
                    MessageBox.Show($"Sửa: {room.Name}");
                    // Sau khi sửa, gọi lại LoadRoomsFromDatabase();
                    LoadRoomsFromDatabase();
                };
                card.DeleteClicked += (s, e) =>
                {
                    if (MessageBox.Show($"Xóa phòng {room.Name}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DataBase.DeleteRoom(room.Id); // Xóa phòng trong CSDL
                        LoadRoomsFromDatabase();
                    }
                };
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var addRoomForm = new AddRoomForm())
            {
                if (addRoomForm.ShowDialog() == DialogResult.OK)
                {
                    LoadRoomsFromDatabase();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            var filtered = allRooms.Where(r => r.Name.ToLower().Contains(keyword)).ToList();
            RenderRooms(filtered);
        }

        // Helper methods to safely get values from dictionary
        private int GetIntValue(Dictionary<string, object> dict, string key)
        {
            if (dict.TryGetValue(key, out var v) && v != null && v != DBNull.Value)
            {
                if (v is int i) return i;
                if (v is long l) return Convert.ToInt32(l);
                if (int.TryParse(v.ToString(), out int result)) return result;
            }
            return 0;
        }

        private string GetStringValue(Dictionary<string, object> dict, string key)
        {
            if (dict.TryGetValue(key, out var v) && v != null && v != DBNull.Value)
                return v.ToString();
            return "";
        }

        private double GetDoubleValue(Dictionary<string, object> dict, string key)
        {
            if (dict.TryGetValue(key, out var v) && v != null && v != DBNull.Value)
            {
                if (v is double d) return d;
                if (v is float f) return Convert.ToDouble(f);
                if (v is decimal m) return Convert.ToDouble(m);
                if (v is int i) return Convert.ToDouble(i);
                if (v is long l) return Convert.ToDouble(l);
                if (double.TryParse(v.ToString(), out double result)) return result;
            }
            return 0;
        }
    }

    // RoomModel mở rộng cho phù hợp với dữ liệu CSDL
    public class RoomModel
    {
        public int Id { get; set; }
        public string Name { get; set; } // RoomNumber
        public string Status { get; set; }
        public string RoomType { get; set; }
        public double Price { get; set; }
    }
}