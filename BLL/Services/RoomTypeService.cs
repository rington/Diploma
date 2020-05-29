using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IUnitOfWork _uow;

        private readonly IMapper _mapper;

        public RoomTypeService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<RoomTypeDTO> GetRoomTypeById(int roomTypeId)
        {
            var roomType = await _uow.RoomTypes.Get(roomTypeId);

            return _mapper.Map<RoomType, RoomTypeDTO>(roomType);
        }

        //public async Task<IEnumerable<RoomTypeDTO>> GetRoomTypesByPrice(double minPrice, double maxPrice)
        //{
        //    var roomTypes = await _uow.RoomTypes.Find(rt => rt.Price >= minPrice && rt.Price <= maxPrice);
        //    return _mapper.Map<IEnumerable<RoomType>, IEnumerable<RoomTypeDTO>>(roomTypes);

        //}
        public async Task<IEnumerable<RoomTypeDTO>> GetAllRoomTypes()
        {
            var roomTypes = await _uow.RoomTypes.GetAll();

            return _mapper.Map<IEnumerable<RoomType>, IEnumerable<RoomTypeDTO>>(roomTypes);
        }

        public async Task AddRoomType(RoomTypeDTO roomType)
        {
            await _uow.RoomTypes.Create(_mapper.Map<RoomTypeDTO, RoomType>(roomType));
        }
        public async Task UpdateRoomType(RoomTypeDTO roomType)
        {
            await _uow.RoomTypes.Update(_mapper.Map<RoomTypeDTO, RoomType>(roomType));
        }

        public bool DeleteRoomType(int roomTypeId)
        {
            return _uow.RoomTypes.Delete(roomTypeId);
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
