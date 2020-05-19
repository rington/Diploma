using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Client
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public double Rating { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
