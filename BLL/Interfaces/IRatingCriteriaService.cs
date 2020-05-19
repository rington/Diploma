using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRatingCriteriaService : IDisposable
    {
        Task<RatingCriteriaDTO> GetRatingById(int ratingCriteriaId);
        Task<IEnumerable<RatingCriteriaDTO>> GetAllRatings();
        Task AddRating(RatingCriteriaDTO ratingCriteria);
        Task UpdateRating(RatingCriteriaDTO ratingCriteria);
        bool DeleteRating(int ratingid);
        Task<IEnumerable<RatingCriteriaDTO>> GetRatingByClientId(int clientId);
        Task<IEnumerable<RatingCriteriaDTO>> GetRatingByByHotelId(int hotelId);
        void SaveChanges();
    }
}
