using DAL.Entities;
using System.Collections.Generic;

namespace BLL.DTOs
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public int HotelId { get; set; }
        public bool IsReserved { get; set; }
        public double Price { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
