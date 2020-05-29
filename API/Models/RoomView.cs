namespace API.Models
{
    public class RoomView
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public int HotelId { get; set; }
        public bool IsReserved { get; set; }
        public double Price { get; set; }
    }
}
