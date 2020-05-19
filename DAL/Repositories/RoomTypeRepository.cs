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
    public class RoomTypeRepository : IRepository<RoomType>
    {
        private readonly HotelContext _db;

        public RoomTypeRepository(HotelContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<RoomType>> GetAll()
        {
            return _db.RoomTypes;
        }

        public async Task<RoomType> Get(int id)
        {
            return _db.RoomTypes.Find(id);
        }

        public async Task<IEnumerable<RoomType>> Find(Func<RoomType, bool> predicate)
        {
            return _db.RoomTypes.Where(predicate).ToList();
        }

        public async Task Create(RoomType roomType)
        {
            _db.RoomTypes.Add(roomType);
        }

        public async Task Update(RoomType roomType)
        {
            _db.Entry(roomType).State = EntityState.Modified;
        }

        public bool Delete(int id)
        {
            var roomType = _db.RoomTypes.Find(id);
            if (roomType != null)
            {
                _db.RoomTypes.Remove(roomType);
                return true;
            }

            return false;
        }
    }
}
