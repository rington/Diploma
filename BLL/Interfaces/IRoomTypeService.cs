using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRoomTypeService : IDisposable
    {
        Task<RoomTypeDTO> GetRoomTypeById(int roomTypeId);
        Task<IEnumerable<RoomTypeDTO>> GetAllRoomTypes();
        //Task<IEnumerable<RoomTypeDTO>> GetRoomTypesByPrice(double minPrice, double maxPrice);
        Task AddRoomType(RoomTypeDTO roomType);
        Task UpdateRoomType(RoomTypeDTO roomType);
        bool DeleteRoomType(int roomTypeId);
        void SaveChanges();
    }
}
