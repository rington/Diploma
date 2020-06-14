using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class RatingCriteria
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        [Range(1, 10, ErrorMessage = "Value must be between 1 to 10")]
        public int Decency { get; set; }
        [Range(1, 10, ErrorMessage = "Value must be between 1 to 10")]
        public int RoomCleanliness { get; set; }
        [Range(1, 10, ErrorMessage = "Value must be between 1 to 10")]
        public int HotelRulesCompliance { get; set; }
        [Range(1, 10, ErrorMessage = "Value must be between 1 to 10")]
        public int Behavior { get; set; }
        [MaxLength(100)]
        public string Comment { get; set; }
    }
}
