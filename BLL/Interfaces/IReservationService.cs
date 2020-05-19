using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IReservationService : IDisposable
    {
        Task<ReservationDTO> GetReservationById(int reservationId);
        Task<IEnumerable<ReservationDTO>> GetAllReservations();
        Task AddReservation(ReservationDTO reservation);
        Task UpdateReservation(ReservationDTO reservation);
        bool DeleteReservation(int reservationId);
        Task<IEnumerable<ReservationDTO>> GetReservationsByDate(DateTime bookingDate, DateTime bookingDateEnd);
        Task<ClientDTO> GetClientByReservation(int reservationId);
        Task<IEnumerable<ClientDTO>> GetClientsByHotel(int hotelId);
        Task<RoomDTO> GetRoomByReservation(int reservationId);
        void SaveChanges();
    }
}
