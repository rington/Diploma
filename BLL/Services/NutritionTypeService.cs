using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NutritionTypeService : INutritionTypeService
    {
        private readonly IUnitOfWork _uow;

        private readonly IMapper _mapper;
        public NutritionTypeService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task AddNutritionType(NutritionTypeDTO nutritionType)
        {
            await _uow.NutritionTypes.Create(_mapper.Map<NutritionTypeDTO, NutritionType>(nutritionType));
        }

        public bool DeleteNutritionType(int nutritionTypeId)
        {
            return _uow.NutritionTypes.Delete(nutritionTypeId);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }

        public async Task<IEnumerable<NutritionTypeDTO>> GetAllNutritionTypes()
        {
            var nutritionTypes = await _uow.NutritionTypes.GetAll();
            return _mapper.Map<IEnumerable<NutritionType>, IEnumerable<NutritionTypeDTO>>(nutritionTypes);
        }

        public async Task<NutritionTypeDTO> GetNutritionTypeById(int nutritionTypeId)
        {
            var nutritionType = await _uow.NutritionTypes.Get(nutritionTypeId);

            return _mapper.Map<NutritionType, NutritionTypeDTO>(nutritionType);
        }

        public void SaveChanges()
        {
            _uow.Save();
        }

        public async Task UpdateNutritionType(NutritionTypeDTO nutritionType)
        {
            await _uow.NutritionTypes.Update(_mapper.Map<NutritionTypeDTO, NutritionType>(nutritionType));
        }
    }
}
