using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _uow;

        private readonly IMapper _mapper;

        public ReservationService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ReservationDTO> GetReservationById(int reservationId)
        {
            var reservation = await _uow.Reservations.Get(reservationId);
            return _mapper.Map<Reservation, ReservationDTO>(reservation);
        }

        public async Task<IEnumerable<ReservationDTO>> GetAllReservations()
        {
            var reservations = await _uow.Reservations.GetAll();
            return _mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationDTO>>(reservations);
        }

        public async Task AddReservation(ReservationDTO reservation)
        {
            await _uow.Reservations.Create(_mapper.Map<ReservationDTO, Reservation>(reservation));
        }

        public async Task UpdateReservation(ReservationDTO reservation)
        {
            await _uow.Reservations.Update(_mapper.Map<ReservationDTO, Reservation>(reservation));
        }

        public bool DeleteReservation(int reservationId)
        {
            return _uow.Reservations.Delete(reservationId);
        }

        public async Task<IEnumerable<ReservationDTO>> GetReservationsByDate(DateTime bookingDate, DateTime bookingDateEnd)
        {
            var reservations =
                await _uow.Reservations.Find(r => r.BookingDate >= bookingDate && r.BookingDateEnd <= bookingDateEnd);
            return _mapper.Map<IEnumerable<Reservation>, IEnumerable<ReservationDTO>>(reservations);
        }

        public async Task<ClientDTO> GetClientByReservation(int reservationId)
        {
            var client = await _uow.Reservations.GetClientByReservation(reservationId);
            return _mapper.Map<Client, ClientDTO>(client);
        }
        //public async Task<IEnumerable<ClientDTO>> GetClientsByHotel(int hotelId)
        //{
        //    var clients = await _uow.Reservations.GetClientsByHotel(hotelId);
        //    return _mapper.Map<IEnumerable<Client>, IEnumerable<ClientDTO>>(clients);
        //}

        public async Task<RoomDTO> GetRoomByReservation(int reservationId)
        {
            var room = await _uow.Reservations.GetRoomByReservation(reservationId);
            return _mapper.Map<Room, RoomDTO>(room);
        }
        public void SaveChanges()
        {
            _uow.Save();
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
