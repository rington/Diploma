using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IHotelService : IDisposable
    {
        Task<HotelDTO> GetHotelById(int hotelId);
        Task<IEnumerable<HotelDTO>> GetAllHotels();
        Task AddHotel(HotelDTO hotel);
        Task UpdateHotel(HotelDTO hotel);
        bool DeleteHotel(int hotelId);
        Task<HotelDTO> GetHotelByName(string hotelName);
        Task<IEnumerable<HotelDTO>> GetHotelsByCity(string city);
        Task<IEnumerable<HotelDTO>> GetHotelsByRating(int rating);
        Task<IEnumerable<HotelDTO>> GetHotelsByNutrition(int nutritionTypeId);
        void SaveChanges();
    }
}
