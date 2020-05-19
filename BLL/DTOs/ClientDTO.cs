using System.Collections.Generic;

namespace BLL.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Rating { get; set; }
        public ICollection<ReservationDTO> Reservation { get; set; }
    }
}
