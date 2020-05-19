using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RatingCriteriaService : IRatingCriteriaService
    {
        private readonly IUnitOfWork _uow;

        private readonly IMapper _mapper;
        public RatingCriteriaService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task AddRating(RatingCriteriaDTO ratingCriteria)
        {
            await _uow.RatingCriterias.Create(_mapper.Map<RatingCriteriaDTO, RatingCriteria>(ratingCriteria));
        }

        public bool DeleteRating(int ratingId)
        {
            return _uow.RatingCriterias.Delete(ratingId);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }

        public async Task<IEnumerable<RatingCriteriaDTO>> GetAllRatings()
        {
            var ratings = await _uow.RatingCriterias.GetAll();
            return _mapper.Map<IEnumerable<RatingCriteria>, IEnumerable<RatingCriteriaDTO>>(ratings);
        }

        public async Task<IEnumerable<RatingCriteriaDTO>> GetRatingByByHotelId(int hotelId)
        {
            var ratings = await _uow.RatingCriterias.Find(r => r.HotelId == hotelId);
            return _mapper.Map<IEnumerable<RatingCriteria>, IEnumerable<RatingCriteriaDTO>>(ratings);
        }

        public async Task<IEnumerable<RatingCriteriaDTO>> GetRatingByClientId(int clientId)
        {
            var ratings = await _uow.RatingCriterias.Find(r => r.ClientId == clientId);
            return _mapper.Map<IEnumerable<RatingCriteria>, IEnumerable<RatingCriteriaDTO>>(ratings);
        }

        public async Task<RatingCriteriaDTO> GetRatingById(int ratingCriteriaId)
        {
            var rating = await _uow.RatingCriterias.Get(ratingCriteriaId);
            return _mapper.Map<RatingCriteria, RatingCriteriaDTO>(rating);
        }

        public void SaveChanges()
        {
            _uow.Save();
        }

        public async Task UpdateRating(RatingCriteriaDTO ratingCriteria)
        {
            await _uow.RatingCriterias.Update(_mapper.Map<RatingCriteriaDTO, RatingCriteria>(ratingCriteria));
        }
    }
}
