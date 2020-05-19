using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAll();
        Task<Client> GetClientByReservation(int reservationId);
        Task<Room> GetRoomByReservation(int reservationId);
        //Task<IEnumerable<Client>> GetClientsByHotel(int hotelId);
        Task<Reservation> Get(int id);
        Task<IEnumerable<Reservation>> Find(Func<Reservation, bool> predicate);
        Task Create(Reservation item);
        Task Update(Reservation item);
        bool Delete(int id);
    }
}
