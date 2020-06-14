using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Hotel
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public int NutritionTypeId { get; set; }
        public NutritionType NutritionType { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public bool HasRoomCleaning { get; set; }
        public bool HasParking { get; set; }
        public double DistanceToCityCenter { get; set; }
        public int Rating { get; set; }
    }
}
