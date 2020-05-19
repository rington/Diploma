using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class NutritionTypeDTO
    {
        public int Id { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public bool IsPaid { get; set; }
    }
}
