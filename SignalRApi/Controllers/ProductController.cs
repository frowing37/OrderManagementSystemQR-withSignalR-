using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR_Business.Abstract;
using SignalR_Dto.ProductDto;
using SignalR_Entities.Concrete;
using AutoMapper;
using SignalR_DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        protected readonly IProductService _productService;
        protected readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.GetListAllwS());

            return Ok(values);
        }

        [HttpGet("{ID}")]
        public IActionResult GetProduct(int ID)
        {
            var value = _productService.GetByIDwS(ID);

            return Ok(value);
        }

        [HttpGet("ProductCount")]
        public IActionResult GetProductCount()
        {
            var count = _productService.getProductCountwS();

            return Ok(count);
        }

        [HttpGet("ProductCountCategoryByDrink")]
        public IActionResult GetProductCountByCategoryDrink()
        {
            var count = _productService.getProductCountCategoryByDrinkwS();

            return Ok(count);
        }
        
        [HttpGet("ProductCountByCategoryBurger")]
        public IActionResult GetProductCountByCategoryBurger()
        {
            var count = _productService.getProductCountCategoryByBurgerwS();

            return Ok(count);
        }

        [HttpGet("DrinkAveragePrice")]
        public IActionResult GetDrinkAveragePrice()
        {
            var count = _productService.getDrinkAveragePricewS();

            return Ok(count);
        }
        
        [HttpGet("BurgerAveragePrice")]
        public IActionResult GetBurgerAveragePrice()
        {
            var count = _productService.getBurgerAveragePricewS();

            return Ok(count);
        }

        [HttpGet("GetProductMinPrice")]
        public IActionResult GetProductMinPrice()
        {
            var count = _productService.getProductByMinPricewS();

            return Ok(count);
        }
        
        [HttpGet("GetProductMaxPrice")]
        public IActionResult GetProductMaxPrice()
        {
            var count = _productService.getProductByMaxPricewS();

            return Ok(count);
        }

        [HttpGet("ProductListwithCategories")]
        public IActionResult ProductListwithCategories()
        {
            var values = _mapper.Map<List<ResultProductwithCategoriesDto>>(_productService.GetProductswithCategorieswS());
            
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            Product product = new Product()
            {
                ProductName = createProductDto.ProductName,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                ImageURL = createProductDto.ImageURL,
                ProductStatus = createProductDto.ProductStatus,
                CategoryID = createProductDto.CategoryID
            };

            _productService.AddwS(product);

            return Ok("Ürün eklendi");
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] UpdateProductDto updateProductDto)
        {
            Product product = new Product()
            {
                ProductID = updateProductDto.ProductID,
                ProductName = updateProductDto.ProductName,
                Description = updateProductDto.Description,
                Price = updateProductDto.Price,
                ImageURL = updateProductDto.ImageURL,
                ProductStatus = updateProductDto.ProductStatus,
                CategoryID = updateProductDto.CategoryID
            };

            _productService.UpdatewS(product);

            return Ok("Ürün güncellendi");
        }

        [HttpDelete("{ID}")]
        public IActionResult DeleteProduct(int ID)
        {
            var value = _productService.GetByIDwS(ID);

            _productService.DeletewS(value);

            return Ok("Ürün silindi");
        }
    }
}

