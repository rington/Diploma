using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class NutritionType
    {
        public int Id { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public bool IsPaid { get; set; }
    }
}
