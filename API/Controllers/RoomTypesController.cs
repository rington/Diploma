using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    public class RoomTypesController : Controller
    {
        private readonly IRoomTypeService _roomTypesService;

        private readonly IMapper _mapper;

        public RoomTypesController(IRoomTypeService service, IMapper mapper)
        {
            _roomTypesService = service;
            _mapper = mapper;
        }

        [Route("api/roomTypes/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var roomType = await _roomTypesService.GetRoomTypeById(id);

            if (roomType == null)
            {
                return NotFound();
            }

            var roomTypeView = _mapper.Map<RoomTypeDTO, RoomTypeView>(roomType);

            return Ok(roomTypeView);
        }

        [Route("api/roomTypes")]
        [HttpGet]
        public async Task<IEnumerable<RoomTypeView>> GetAll()
        {
            var roomTypes = await _roomTypesService.GetAllRoomTypes();

            return _mapper.Map<IEnumerable<RoomTypeDTO>, IEnumerable<RoomTypeView>>(roomTypes);
        }
        [Route("api/roomTypes/price/{minPrice}/{maxPrice}")]
        [HttpGet]
        public async Task<IEnumerable<RoomTypeView>> GetRoomTypeByPrice(double minPrice, double maxPrice)
        {
            var roomTypes = await _roomTypesService.GetRoomTypesByPrice(minPrice, maxPrice);

            return _mapper.Map<IEnumerable<RoomTypeDTO>, IEnumerable<RoomTypeView>>(roomTypes);
        }

        [Route("api/roomTypes")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]RoomTypeView roomType)
        {
            var roomTypeDTO = _mapper.Map<RoomTypeView, RoomTypeDTO>(roomType);

            await _roomTypesService.AddRoomType(roomTypeDTO);

            _roomTypesService.SaveChanges();

            return Ok();
        }

        [Route("api/roomTypes")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]RoomTypeView roomType)
        {
            var roomTypeDTO = _mapper.Map<RoomTypeView, RoomTypeDTO>(roomType);

            await _roomTypesService.UpdateRoomType(roomTypeDTO);

            _roomTypesService.SaveChanges();

            return Ok();
        }

        [Route("api/roomTypes/{id:int}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_roomTypesService.DeleteRoomType(id))
            {
                _roomTypesService.SaveChanges();

                return Ok();
            }

            return NotFound();
        }
    }
}
