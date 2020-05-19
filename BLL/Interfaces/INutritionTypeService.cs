using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface INutritionTypeService : IDisposable
    {
        Task<NutritionTypeDTO> GetNutritionTypeById(int nutritionTypeId);
        Task<IEnumerable<NutritionTypeDTO>> GetAllNutritionTypes();
        Task AddNutritionType(NutritionTypeDTO nutritionType);
        Task UpdateNutritionType(NutritionTypeDTO nutritionType);
        bool DeleteNutritionType(int nutritionTypeId);
        void SaveChanges();
    }
}
