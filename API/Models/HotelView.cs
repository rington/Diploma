namespace API.Models
{
    public class HotelView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int NutritionTypeId { get; set; }
        public bool HasRoomCleaning { get; set; }
        public bool HasParking { get; set; }
        public double DistanceToCityCenter { get; set; }
        public int Rating { get; set; }
    }
}
