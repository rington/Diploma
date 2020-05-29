using BLL.DTOs;
using DAL.Entities;
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
        Task<IEnumerable<HotelDTO>> GetHotelsByRoomCleaning(bool hasRoomCleaning);
        Task<IEnumerable<HotelDTO>> GetHotelsByParking(bool hasParking);
        Task<IEnumerable<HotelDTO>> GetHotelsByRatingArray(int rat1, int rat2, int rat3);
        Task<IEnumerable<HotelDTO>> GetHotelsByDistanceArray(double dist1, double dist2, double dist3);
        Task<IEnumerable<HotelDTO>> GetHotelsByNutritionArray(int ro, int bb, int hb, int fb, int ai);
        void SaveChanges();
    }
}
