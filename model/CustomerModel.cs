namespace HotelManagement
{
    public class CustomerModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int SexId { get; set; }
        public string Birth { get; set; }
        // Nếu cần dùng trong CustomerManagerForm, có thể thêm:
        public string Gender { get; set; }
    }
}
