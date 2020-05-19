using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomsService;

        private readonly IMapper _mapper;

        public RoomsController(IRoomService service, IMapper mapper)
        {
            _roomsService = service;
            _mapper = mapper;
        }

        [Route("api/rooms/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var room = await _roomsService.GetRoomById(id);

            if (room == null)
            {
                return NotFound();
            }

            var roomView = _mapper.Map<RoomDTO, RoomView>(room);

            return Ok(roomView);
        }

        [Route("api/rooms")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]RoomView room)
        {
            var roomDTO = _mapper.Map<RoomView, RoomDTO>(room);

            await _roomsService.AddRoom(roomDTO);

            _roomsService.SaveChanges();

            return Ok();
        }

        [Route("api/rooms")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]RoomView room)
        {
            var roomDTO = _mapper.Map<RoomView, RoomDTO>(room);

            await _roomsService.UpdateRoom(roomDTO);

            _roomsService.SaveChanges();

            return Ok();
        }

        [Route("api/rooms/{id:int}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_roomsService.DeleteRoom(id))
            {
                _roomsService.SaveChanges();

                return Ok();
            }

            return NotFound();
        }

        [Route("api/rooms/hotel/{hotelId:int}")]
        [HttpGet]
        public async Task<IEnumerable<RoomView>> GetRoomsByHotel(int hotelId)
        {
            var rooms = await _roomsService.GetRoomsByHotel(hotelId);

            return _mapper.Map<IEnumerable<RoomDTO>, IEnumerable<RoomView>>(rooms);
        }
        [Route("api/rooms/roomType/{roomTypeId:int}")]
        [HttpGet]
        public async Task<IEnumerable<RoomView>> GetRoomsByRoomType(int roomTypeId)
        {
            var rooms = await _roomsService.GetRoomsByRoomType(roomTypeId);

            return _mapper.Map<IEnumerable<RoomDTO>, IEnumerable<RoomView>>(rooms);
        }
    }
}
