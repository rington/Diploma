using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class HotelService : IHotelService
    {
        private readonly IUnitOfWork _uow;

        private readonly IMapper _mapper;

        public HotelService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<HotelDTO> GetHotelById(int hotelId)
        {
            var hotel = await _uow.Hotels.Get(hotelId);
            return _mapper.Map<Hotel, HotelDTO>(hotel);
        }

        public async Task<IEnumerable<HotelDTO>> GetAllHotels()
        {
            var hotels = await _uow.Hotels.GetAll();
            return _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDTO>>(hotels);
        }
        public async Task AddHotel(HotelDTO hotel)
        {
            await _uow.Hotels.Create(_mapper.Map<HotelDTO, Hotel>(hotel));
        }
        public async Task UpdateHotel(HotelDTO hotel)
        {
            await _uow.Hotels.Update(_mapper.Map<HotelDTO, Hotel>(hotel));
        }

        public bool DeleteHotel(int hotelId)
        {
            return _uow.Hotels.Delete(hotelId);
        }

        public async Task<HotelDTO> GetHotelByName(string hotelName)
        {
            var hotel = (await _uow.Hotels.Find(h => h.Name == hotelName)).First();
            return _mapper.Map<Hotel, HotelDTO>(hotel);
        }

        public async Task<IEnumerable<HotelDTO>> GetHotelsByCity(string city)
        {
            var hotels = await _uow.Hotels.Find(h => h.City == city);
            return _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDTO>>(hotels);
        }

        public async Task<IEnumerable<HotelDTO>> GetHotelsByRating(int rating)
        {
            var hotels = await _uow.Hotels.Find(h => h.Rating == rating);
            return _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDTO>>(hotels);
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
