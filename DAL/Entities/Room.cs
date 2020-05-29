using System.Collections.Generic;

namespace DAL.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public bool IsReserved { get; set; }
        public double Price { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
