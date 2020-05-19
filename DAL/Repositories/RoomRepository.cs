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
    public class RoomRepository : IRepository<Room>
    {
        private readonly HotelContext _db;

        public RoomRepository(HotelContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            return _db.Rooms;
        }

        public async Task<Room> Get(int id)
        {
            return _db.Rooms.Find(id);
        }

        public async Task Create(Room room)
        {
            _db.Rooms.Add(room);
        }

        public async Task Update(Room room)
        {
            _db.Entry(room).State = EntityState.Modified;
        }

        public async Task<IEnumerable<Room>> Find(Func<Room, bool> predicate)
        {
            return _db.Rooms.Where(predicate).ToList();
        }

        public bool Delete(int id)
        {
            var room = _db.Rooms.Find(id);

            if (room != null)
            {
                _db.Rooms.Remove(room);
                return true;
            }

            return false;
        }
    }
}
