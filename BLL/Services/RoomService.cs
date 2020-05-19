using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _uow;

        private readonly IMapper _mapper;

        public RoomService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<RoomDTO> GetRoomById(int roomId)
        {
            var room = await _uow.Rooms.Get(roomId);

            return _mapper.Map<Room, RoomDTO>(room);
        }

        public async Task<IEnumerable<RoomDTO>> GetRoomsByHotel(int hotelId)
        {
            var rooms = await _uow.Rooms.Find(r => r.HotelId == hotelId);
            return _mapper.Map<IEnumerable<Room>, IEnumerable<RoomDTO>>(rooms);

        }

        public async Task<IEnumerable<RoomDTO>> GetRoomsByRoomType(int roomTypeId)
        {
            var rooms = await _uow.Rooms.Find(r => r.RoomTypeId == roomTypeId);
            return _mapper.Map<IEnumerable<Room>, IEnumerable<RoomDTO>>(rooms);
        }
        public async Task AddRoom(RoomDTO room)
        {
            await _uow.Rooms.Create(_mapper.Map<RoomDTO, Room>(room));
        }
        public async Task UpdateRoom(RoomDTO room)
        {
            await _uow.Rooms.Update(_mapper.Map<RoomDTO, Room>(room));
        }

        public bool DeleteRoom(int roomId)
        {
            return _uow.Rooms.Delete(roomId);
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
