using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelService _hotelsService;

        private readonly IMapper _mapper;

        public HotelsController(IHotelService service, IMapper mapper)
        {
            _hotelsService = service;
            _mapper = mapper;
        }

        [Route("api/hotels/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var hotel = await _hotelsService.GetHotelById(id);

            if (hotel == null)
            {
                return NotFound();
            }

            var hotelView = _mapper.Map<HotelDTO, HotelView>(hotel);

            return Ok(hotelView);
        }

        [Route("api/hotels")]
        [HttpGet]
        public async Task<IEnumerable<HotelView>> GetAll()
        {
            var hotels = await _hotelsService.GetAllHotels();

            return _mapper.Map<IEnumerable<HotelDTO>, IEnumerable<HotelView>>(hotels);
        }

        [Route("api/hotels")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]HotelView hotel)
        {
            var hotelDTO = _mapper.Map<HotelView, HotelDTO>(hotel);

            await _hotelsService.AddHotel(hotelDTO);

            _hotelsService.SaveChanges();

            return Ok();
        }

        [Route("api/hotels")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]HotelView hotel)
        {
            var hotelDTO = _mapper.Map<HotelView, HotelDTO>(hotel);

            await _hotelsService.UpdateHotel(hotelDTO);

            _hotelsService.SaveChanges();

            return Ok();
        }

        [Route("api/hotels/{id:int}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (_hotelsService.DeleteHotel(id))
            {
                _hotelsService.SaveChanges();

                return Ok();
            }

            return NotFound();
        }

        [Route("api/hotels/name/{name}")]
        [HttpGet]
        public async Task<HotelView> GetHotelByName(string name)
        {
            var hotels = await _hotelsService.GetHotelByName(name);

            return _mapper.Map<HotelDTO, HotelView>(hotels);
        }
        [Route("api/hotels/city/{city}")]
        [HttpGet]
        public async Task<IEnumerable<HotelView>> GetHotelsByCity(string city)
        {
            var hotels = await _hotelsService.GetHotelsByCity(city);

            return _mapper.Map<IEnumerable<HotelDTO>,IEnumerable<HotelView>>(hotels);
        }

        [Route("api/hotels/nutritionType/{nutritionTypeId}")]
        [HttpGet]
        public async Task<IEnumerable<HotelView>> GetHotelsByNutrition(int nutritionTypeId)
        {
            var hotels = await _hotelsService.GetHotelsByNutrition(nutritionTypeId);

            return _mapper.Map<IEnumerable<HotelDTO>, IEnumerable<HotelView>>(hotels);
        }

        [Route("api/hotels/rating/{rating}")]
        [HttpGet]
        public async Task<IEnumerable<HotelView>> GetHotelByRating(int rating)
        {
            var hotels = await _hotelsService.GetHotelsByRating(rating);

            return _mapper.Map<IEnumerable<HotelDTO>, IEnumerable<HotelView>>(hotels);
        }

        [Route("api/hotels/roomCleaning/{hasRoomCleaning}")]
        [HttpGet]
        public async Task<IEnumerable<HotelView>> GetHotelByRoomCleaning(bool hasRoomCleaning)
        {
            var hotels = await _hotelsService.GetHotelsByRoomCleaning(hasRoomCleaning);

            return _mapper.Map<IEnumerable<HotelDTO>, IEnumerable<HotelView>>(hotels);
        }

        [Route("api/hotels/parking/{hasParking}")]
        [HttpGet]
        public async Task<IEnumerable<HotelView>> GetHotelByParking(bool hasParking)
        {
            var hotels = await _hotelsService.GetHotelsByParking(hasParking);

            return _mapper.Map<IEnumerable<HotelDTO>, IEnumerable<HotelView>>(hotels);
        }

        [Route("api/hotels/ratingArray/{rat1}/{rat2}/{rat3}")]
        [HttpGet]
        public async Task<IEnumerable<HotelView>> GetHotelsByRatingArray(int rat1, int rat2, int rat3)
        {
            var hotels = await _hotelsService.GetHotelsByRatingArray(rat1, rat2, rat3);

            return _mapper.Map<IEnumerable<HotelDTO>, IEnumerable<HotelView>>(hotels);
        }

        [Route("api/hotels/distance/{dist1}/{dist2}/{dist3}")]
        [HttpGet]
        public async Task<IEnumerable<HotelView>> GetHotelsByDistanceArray(double dist1, double dist2, double dist3)
        {
            var hotels = await _hotelsService.GetHotelsByDistanceArray(dist1, dist2, dist3);

            return _mapper.Map<IEnumerable<HotelDTO>, IEnumerable<HotelView>>(hotels);
        }
        
        [Route("api/hotels/nutritionArray/{ro}/{bb}/{hb}/{fb}/{ai}")]
        [HttpGet]
        public async Task<IEnumerable<HotelView>> GetHotelsByNutritionArray(int ro, int bb, int hb, int fb, int ai)
        {
            var hotels = await _hotelsService.GetHotelsByNutritionArray(ro, bb, hb,fb,ai);

            return _mapper.Map<IEnumerable<HotelDTO>, IEnumerable<HotelView>>(hotels);
        }
    }
}
