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
    public class RatingCriteriaRepository : IRepository<RatingCriteria>
    {
        private readonly HotelContext _db;

        public RatingCriteriaRepository(HotelContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<RatingCriteria>> GetAll()
        {
            return _db.RatingCriterias;
        }

        public async Task<RatingCriteria> Get(int id)
        {
            return await Task.FromResult(_db.RatingCriterias.Find(id));
        }

        public async Task<IEnumerable<RatingCriteria>> Find(Func<RatingCriteria, bool> predicate)
        {
            return _db.RatingCriterias.Where(predicate).ToList();
        }

        public async Task Create(RatingCriteria ratingCriteria)
        {
            _db.RatingCriterias.Add(ratingCriteria);
        }

        public async Task Update(RatingCriteria ratingCriteria)
        {
            _db.Entry(ratingCriteria).State = EntityState.Modified;
        }
        public bool Delete(int id)
        {
            var ratingCriteria = _db.RatingCriterias.Find(id);
            if (ratingCriteria != null)
            {
                _db.RatingCriterias.Remove(ratingCriteria);
                return true;
            }

            return false;
        }
    }
}
