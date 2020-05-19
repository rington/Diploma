using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRoomService : IDisposable
    {
        Task<RoomDTO> GetRoomById(int roomId);
        Task AddRoom(RoomDTO room);
        Task UpdateRoom(RoomDTO room);
        bool DeleteRoom(int roomId);
        Task<IEnumerable<RoomDTO>> GetRoomsByRoomType(int roomTypeId);
        Task<IEnumerable<RoomDTO>> GetRoomsByHotel(int hotelId);
        void SaveChanges();
    }
}
