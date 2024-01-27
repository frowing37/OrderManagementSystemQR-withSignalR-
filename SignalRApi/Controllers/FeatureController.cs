using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR_Business.Abstract;
using SignalR_Dto.FeatureDto;
using SignalR_Entities.Concrete;
using AutoMapper;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    public class FeatureController : Controller
    {
        protected readonly IFeatureService _featureService;
        protected readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Featurelist()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.GetListAllwS());

            return Ok(values);
        }

        [HttpGet("{ID}")]
        public IActionResult GetFeature(int ID)
        {
            var value = _featureService.GetByIDwS(ID);

            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateFeature([FromBody] CreateFeatureDto createFeatureDto)
        {
            Feature feature = new Feature()
            {
                Title1 = createFeatureDto.Title1,
                Description1 = createFeatureDto.Description1,
                Title2 = createFeatureDto.Title2,
                Description2 = createFeatureDto.Description2,
                Title3 = createFeatureDto.Title3,
                Description3 = createFeatureDto.Description3
            };

            _featureService.AddwS(feature);

            return Ok("Özellik eklendi");
        }

        [HttpPut]
        public IActionResult UpdateFeature([FromBody] UpdateFeatureDto updateFeatureDto)
        {
            Feature feature = new Feature()
            {
                FeatureID = updateFeatureDto.FeatureID,
                Title1 = updateFeatureDto.Title1,
                Description1 = updateFeatureDto.Description1,
                Title2 = updateFeatureDto.Title2,
                Description2 = updateFeatureDto.Description2,
                Title3 = updateFeatureDto.Title3,
                Description3 = updateFeatureDto.Description3
            };

            _featureService.UpdatewS(feature);

            return Ok("Özellik güncellendi");
        }

        [HttpDelete("{ID}")]
        public IActionResult DeleteFeature(int ID)
        {
            var value = _featureService.GetByIDwS(ID);

            _featureService.DeletewS(value);

            return Ok("Özellik silindi");
        }
    }
}

