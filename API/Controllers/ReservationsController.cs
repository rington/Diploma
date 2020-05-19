using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API
{
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationsService;

        private readonly IMapper _mapper;

        public ReservationsController(IReservationService service, IMapper mapper)
        {
            _reservationsService = service;
            _mapper = mapper;
        }

        [Route("api/reservations/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var reservation = await _reservationsService.GetReservationById(id);

            if (reservation == null)
            {
                return NotFound();
            }

            var reservationView = _mapper.Map<ReservationDTO, ReservationView>(reservation);

            return Ok(reservationView);
        }
        [Route("api/reservations")]
        [HttpGet]
        public async Task<IEnumerable<ReservationView>> GetAll()
        {
            var reservations = await _reservationsService.GetAllReservations();

            return _mapper.Map<IEnumerable<ReservationDTO>, IEnumerable<ReservationView>>(reservations);
        }

        [Route("api/reservations")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ReservationView reservation)
        {
            var reservationDTO = _mapper.Map<ReservationView, ReservationDTO>(reservation);

            await _reservationsService.AddReservation(reservationDTO);

            _reservationsService.SaveChanges();

            return Ok();
        }

        [Route("api/reservations")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ReservationView reservation)
        {
            var reservationDTO = _mapper.Map<ReservationView, ReservationDTO>(reservation);

            await _reservationsService.UpdateReservation(reservationDTO);

            _reservationsService.SaveChanges();

            return Ok();
        }

        [Route("api/reservations/{id:int}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_reservationsService.DeleteReservation(id))
            {
                _reservationsService.SaveChanges();

                return Ok();
            }

            return NotFound();
        }

        [Route("api/reservations/dateInterval/{bookingDate}/{bookingDateEnd}")]
        [HttpGet]
        public async Task<IEnumerable<ReservationView>> GetReservationByDate(DateTime bookingDate, DateTime bookingDateEnd)
        {
            var reservations = await _reservationsService.GetReservationsByDate(bookingDate, bookingDateEnd);

            return _mapper.Map<IEnumerable<ReservationDTO>, IEnumerable<ReservationView>>(reservations);
        }
        [Route("api/reservations/{reservationId:int}/client")]
        [HttpGet]
        public async Task<ClientView> GetClientByReservation(int reservationId)
        {
            var client = await _reservationsService.GetClientByReservation(reservationId);

            return _mapper.Map<ClientDTO, ClientView>(client);
        }

        [Route("api/hotels/{hotelId:int}/clients")]
        [HttpGet]
        public async Task<IEnumerable<ClientView>> GetClientByHotel(int hotelId)
        {
            var clients = await _reservationsService.GetClientsByHotel(hotelId);

            return _mapper.Map<IEnumerable<ClientDTO>, IEnumerable<ClientView>>(clients);
        }

        [Route("api/reservations/{reservationId:int}/room")]
        [HttpGet]
        public async Task<RoomView> GetRoomByReservation(int reservationId)
        {
            var room = await _reservationsService.GetRoomByReservation(reservationId);

            return _mapper.Map<RoomDTO, RoomView>(room);
        }

    }
}
