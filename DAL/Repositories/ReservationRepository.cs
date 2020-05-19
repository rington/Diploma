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
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelContext _db;

        public ReservationRepository(HotelContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return _db.Reservations;
        }

        public async Task<Client> GetClientByReservation(int reservationId)
        {
            return _db.Reservations.Include(r => r.Client).First(r => r.Id == reservationId).Client;
        }
        //public async Task<IEnumerable<Client>> GetClientsByHotel(int hotelId)
        //{
        //    return _db.Reservations.Include(r => r.Client).Include(r => r.Hotel).Where(r => r.HotelId == hotelId).Select(r => r.Client);
        //}

        public async Task<Room> GetRoomByReservation(int reservationId)
        {
            return _db.Reservations.Include(r => r.Room).First(r => r.Id == reservationId).Room;
        }

        public async Task<Reservation> Get(int id)
        {
            return _db.Reservations.Find(id);
        }

        public async Task<IEnumerable<Reservation>> Find(Func<Reservation, bool> predicate)
        {
            return _db.Reservations.Where(predicate).ToList();
        }

        public async Task Create(Reservation reservation)
        {
            _db.Reservations.Add(reservation);
        }

        public async Task Update(Reservation reservation)
        {
            _db.Entry(reservation).State = EntityState.Modified;
        }

        public bool Delete(int id)
        {
            var reservation = _db.Reservations.Find(id);
            if (reservation != null)
            {
                _db.Reservations.Remove(reservation);
                return true;
            }

            return false;
        }
    }
}
