﻿namespace API.Models
{
    public class NutritionTypeView
    {
        public int Id { get; set; }        
        public string Name { get; set; }        
        public string Description { get; set; }
        public bool IsPaid { get; set; }
    }
}
