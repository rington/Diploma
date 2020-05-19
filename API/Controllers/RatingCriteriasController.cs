using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    public class RatingCriteriasController : Controller
    {
        private readonly IRatingCriteriaService _ratingCriteriaService;

        private readonly IMapper _mapper;

        public RatingCriteriasController(IRatingCriteriaService service, IMapper mapper)
        {
            _ratingCriteriaService = service;
            _mapper = mapper;
        }

        [Route("api/rating")]
        [HttpPost]
        public async Task<IActionResult> AddRating(RatingCriteriaView ratingCriteria)
        {
            var ratingCriteriaDTO = _mapper.Map<RatingCriteriaView, RatingCriteriaDTO>(ratingCriteria);

            await _ratingCriteriaService.AddRating(ratingCriteriaDTO);

            _ratingCriteriaService.SaveChanges();

            return Ok();
        }

        [Route("api/rating")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]RatingCriteriaView rating)
        {
            var ratingDTO = _mapper.Map<RatingCriteriaView, RatingCriteriaDTO>(rating);

            await _ratingCriteriaService.UpdateRating(ratingDTO);

            _ratingCriteriaService.SaveChanges();

            return Ok();
        }

        [Route("api/rating/{id:int}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_ratingCriteriaService.DeleteRating(id))
            {
                _ratingCriteriaService.SaveChanges();

                return Ok();
            }

            return NotFound();
        }

        [Route("api/rating/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetRatingById(int ratingCriteriaId)
        {
            var rating = await _ratingCriteriaService.GetRatingById(ratingCriteriaId);

            if (rating == null)
            {
                return NotFound();
            }

            var roomView = _mapper.Map<RatingCriteriaDTO, RatingCriteriaView>(rating);

            return Ok(roomView);
        }

        [Route("api/rating/")]
        [HttpGet]
        public async Task<IEnumerable<RatingCriteriaView>> GetAllRatings()
        {

            var rating = await _ratingCriteriaService.GetAllRatings();

            return _mapper.Map<IEnumerable<RatingCriteriaDTO>, IEnumerable<RatingCriteriaView>>(rating);
        }

        [Route("api/rating/clients/{clientId:int}")]
        [HttpGet]
        public async Task<IEnumerable<RatingCriteriaView>> GetRatingByClientId(int clientId)
        {

            var rating = await _ratingCriteriaService.GetRatingByClientId(clientId);

            return _mapper.Map<IEnumerable<RatingCriteriaDTO>, IEnumerable<RatingCriteriaView>>(rating);
        }

        [Route("api/rating/hotels/{hotelId:int}")]
        [HttpGet]
        public async Task<IEnumerable<RatingCriteriaView>> GetRatingByByHotelId(int hotelId)
        {
            var rating = await _ratingCriteriaService.GetRatingByByHotelId(hotelId);

            return _mapper.Map<IEnumerable<RatingCriteriaDTO>, IEnumerable<RatingCriteriaView>>(rating);
        }
    }
}
