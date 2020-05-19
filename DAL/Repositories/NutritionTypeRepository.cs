using DAL.DBContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class NutritionTypeRepository : IRepository<NutritionType>
    {
        private readonly HotelContext _db;

        public NutritionTypeRepository(HotelContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<NutritionType>> GetAll()
        {
            return _db.NutritionTypes;
        }

        public async Task<NutritionType> Get(int id)
        {
            return _db.NutritionTypes.Find(id);
        }

        public async Task<IEnumerable<NutritionType>> Find(Func<NutritionType, bool> predicate)
        {
            return _db.NutritionTypes.Where(predicate).ToList();
        }

        public async Task Create(NutritionType nutritionType)
        {
            _db.NutritionTypes.Add(nutritionType);
        }

        public async Task Update(NutritionType nutritionType)
        {
            _db.Entry(nutritionType).State = EntityState.Modified;
        }

        public bool Delete(int id)
        {
            var nutritionType = _db.NutritionTypes.Find(id);
            if (nutritionType != null)
            {
                _db.NutritionTypes.Remove(nutritionType);
                return true;
            }

            return false;
        }
    }
}
