public class InvoiceModel
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string StaffCheckOut { get; set; }
    public string CustomerCheckOut { get; set; }
    public double TotalPrice { get; set; }
    public string CheckInDate { get; set; }
    public string CheckOutDate { get; set; }
}