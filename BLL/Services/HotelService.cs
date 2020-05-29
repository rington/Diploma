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

        public async Task<IEnumerable<HotelDTO>> GetHotelsByNutrition(int nutritionTypeId)
        {
            var hotels = await _uow.Hotels.Find(h => h.NutritionTypeId == nutritionTypeId);
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

        public async Task<IEnumerable<HotelDTO>> GetHotelsByRoomCleaning(bool hasRoomCleaning)
        {
            var hotels = await _uow.Hotels.Find(h => h.HasRoomCleaning == hasRoomCleaning);
            return _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDTO>>(hotels);
        }

        public async Task<IEnumerable<HotelDTO>> GetHotelsByParking(bool hasParking)
        {
            var hotels = await _uow.Hotels.Find(h => h.HasParking == hasParking);
            return _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDTO>>(hotels);
        }

        public async Task<IEnumerable<HotelDTO>> GetHotelsByRatingArray(int rat1, int rat2, int rat3)
        {
            var hotels = await _uow.Hotels.Find(h => h.Rating == rat1 || h.Rating == rat2 || h.Rating == rat3);
            return _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDTO>>(hotels);
        }

        public async Task<IEnumerable<HotelDTO>> GetHotelsByDistanceArray(double dist1, double dist2, double dist3)
        {
            var hotelsList = new List<Hotel>();
            IEnumerable<Hotel> hotels = null;
            if (dist1 != 0)
            {
                hotels = await _uow.Hotels.Find(h => h.DistanceToCityCenter < dist1);
                hotelsList.AddRange(hotels);
            }
            if(dist2 != 0)
            {
                hotels = await _uow.Hotels.Find(h => h.DistanceToCityCenter >= 1 && h.DistanceToCityCenter <= dist2);
                hotelsList.AddRange(hotels);
            }
            if(dist3 != 0)
            {
                hotels = await _uow.Hotels.Find(h => h.DistanceToCityCenter > dist3);
                hotelsList.AddRange(hotels);
            }           
            
            return _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDTO>>(hotelsList);
        }

        public async Task<IEnumerable<HotelDTO>> GetHotelsByNutritionArray(int ro, int bb, int hb, int fb, int ai)
        {
            var hotels = await _uow.Hotels.Find(h => h.NutritionTypeId == ro || h.NutritionTypeId == bb || h.NutritionTypeId == hb || h.NutritionTypeId == fb || h.NutritionTypeId == ai);
            return _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDTO>>(hotels);
        }
    }
}
