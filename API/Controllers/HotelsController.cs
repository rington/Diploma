using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
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
        [Route("api/hotels/rating/{rating}")]
        [HttpGet]
        public async Task<IEnumerable<HotelView>> GetHotelByRating(int rating)
        {
            var hotels = await _hotelsService.GetHotelsByRating(rating);

            return _mapper.Map<IEnumerable<HotelDTO>, IEnumerable<HotelView>>(hotels);
        }
    }
}
