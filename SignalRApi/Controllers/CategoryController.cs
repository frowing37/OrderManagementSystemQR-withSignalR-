using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR_Business.Abstract;
using SignalR_Dto.CategoryDto;
using SignalR_Entities.Concrete;
using AutoMapper;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.GetListAllwS());

            return Ok(values);
        }

        [HttpGet("{ID}")]
        public IActionResult GetCategory(int ID)
        {
            var value = _categoryService.GetByIDwS(ID);

            return Ok(value);
        }
        
        [HttpGet("CategoryCount")]
        public IActionResult GetCategoryCount()
        {
            var count = _categoryService.getCategoryCountwS();
            return Ok(count);
        }
        
        [HttpGet("ActiveCategoryCount")]
        public IActionResult GetActiveCategoryCount()
        {
            var count = _categoryService.getActiveCategoryCountwS();
            return Ok(count);
        }
        
        [HttpGet("PassiveCategoryCount")]
        public IActionResult GetPassiveCategoryCount()
        {
            var count = _categoryService.getPassiveCategoryCountwS();
            return Ok(count);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            Category category = new Category()
            {
                Name = createCategoryDto.Name,
                Status = createCategoryDto.Status
            };

            _categoryService.AddwS(category);

            return Ok("Kategori eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCategory([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            Category category = new Category()
            {
                CategoryID = updateCategoryDto.CategoryID,
                Name = updateCategoryDto.Name,
                Status = updateCategoryDto.Status
            };

            _categoryService.UpdatewS(category);

            return Ok("Kategori güncellendi");
        }

        [HttpDelete("{ID}")]
        public IActionResult DeleteCategory(int ID)
        {
            var value = _categoryService.GetByIDwS(ID);

            _categoryService.DeletewS(value);

            return Ok("Kategori Silindi");
        }
    }
}

