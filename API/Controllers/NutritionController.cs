using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class NutritionController : ControllerBase
    {
        private readonly INutritionTypeService _nutritionTypeService;

        private readonly IMapper _mapper;

        public NutritionController(INutritionTypeService service, IMapper mapper)
        {
            _nutritionTypeService = service;
            _mapper = mapper;
        }

        [Route("api/nutritionTypes/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var nutritionType = await _nutritionTypeService.GetNutritionTypeById(id);

            if (nutritionType == null)
            {
                return NotFound();
            }

            var nutritionTypeView = _mapper.Map<NutritionTypeDTO, NutritionTypeView>(nutritionType);

            return Ok(nutritionTypeView);
        }

        [Route("api/nutritionTypes")]
        [HttpGet]
        public async Task<IEnumerable<NutritionTypeView>> GetAll()
        {
            var nutritionTypes = await _nutritionTypeService.GetAllNutritionTypes();

            return _mapper.Map<IEnumerable<NutritionTypeDTO>, IEnumerable<NutritionTypeView>>(nutritionTypes);
        }


        [Route("api/nutritionTypes")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]NutritionTypeView nutritionType)
        {
            var nutritionTypesDTO = _mapper.Map<NutritionTypeView, NutritionTypeDTO>(nutritionType);

            await _nutritionTypeService.AddNutritionType(nutritionTypesDTO);

            _nutritionTypeService.SaveChanges();

            return Ok();
        }

        [Route("api/nutritionTypes")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]NutritionTypeView nutritionType)
        {
            var nutritionTypeDTo = _mapper.Map<NutritionTypeView, NutritionTypeDTO>(nutritionType);

            await _nutritionTypeService.UpdateNutritionType(nutritionTypeDTo);

            _nutritionTypeService.SaveChanges();

            return Ok();
        }

        [Route("api/nutritionTypes/{id:int}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_nutritionTypeService.DeleteNutritionType(id))
            {
                _nutritionTypeService.SaveChanges();
                return Ok();
            }

            return NotFound();
        }
    }
}