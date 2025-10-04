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
            var roomDicts = DataBase.GetAllRooms();
            foreach (var dict in roomDicts)
            {
                allRooms.Add(new RoomModel
                {
                    Id = Convert.ToInt32(dict["Id"]),
                    Name = dict["RoomNumber"].ToString(),
                    Status = dict["Status"].ToString(),
                    RoomType = dict.ContainsKey("TypeName") ? dict["TypeName"].ToString() : "",
                    Price = dict.ContainsKey("Price") ? Convert.ToDouble(dict["Price"]) : 0
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
                    // Sau khi nhập thông tin, bạn sẽ lấy dữ liệu từ addRoomForm để thêm phòng
                    // Ví dụ:
                    // DataBase.AddRoom(addRoomForm.RoomNumber, addRoomForm.RoomTypeId, addRoomForm.Status);
                    // LoadRoomsFromDatabase();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            var filtered = allRooms.Where(r => r.Name.ToLower().Contains(keyword)).ToList();
            RenderRooms(filtered);
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