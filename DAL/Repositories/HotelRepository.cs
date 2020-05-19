﻿using DAL.DBContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class HotelRepository : IRepository<Hotel>
    {
        private readonly HotelContext _db;

        public HotelRepository(HotelContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Hotel>> GetAll()
        {
            return _db.Hotels;
        }

        public async Task<Hotel> Get(int id)
        {
            return _db.Hotels.Find(id);
        }

        public async Task<IEnumerable<Hotel>> Find(Func<Hotel, bool> predicate)
        {
            return _db.Hotels.Where(predicate).ToList();
        }

        public async Task Create(Hotel hotel)
        {
            _db.Hotels.Add(hotel);
        }

        public async Task Update(Hotel hotel)
        {
            _db.Entry(hotel).State = EntityState.Modified;
        }

        public bool Delete(int id)
        {
            var hotel = _db.Hotels.Find(id);
            if (hotel != null)
            {
                _db.Hotels.Remove(hotel);
                return true;
            }

            return false;
        }
    }
}
