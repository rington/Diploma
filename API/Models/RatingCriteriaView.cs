﻿namespace API.Models
{
    public class RatingCriteriaView
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int HotelId { get; set; }
        public int Decency { get; set; }
        public int RoomCleanliness { get; set; }
        public int HotelRulesCompliance { get; set; }
        public int Behavior { get; set; }
        public string Comment { get; set; }
    }
}
