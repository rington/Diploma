using System;
using System.Collections.Generic;

namespace BLL.DTOs
{
    public class HotelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public ICollection<ReservationDTO> Reservation { get; set; }
    }
}
