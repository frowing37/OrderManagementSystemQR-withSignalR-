using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR_Business.Abstract;
using SignalR_Dto.ProductDto;
using SignalR_Entities.Concrete;
using AutoMapper;

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

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int ID)
        {
            var value = _productService.GetByIDwS(ID);

            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            Product product = new Product()
            {
                ProductName = createProductDto.ProductName,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                ImageURL = createProductDto.ImageURL,
                ProductStatus = createProductDto.ProductStatus
            };

            _productService.AddwS(product);

            return Ok("Ürün eklendi");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            Product product = new Product()
            {
                ProductID = updateProductDto.ProductID,
                ProductName = updateProductDto.ProductName,
                Description = updateProductDto.Description,
                Price = updateProductDto.Price,
                ImageURL = updateProductDto.ImageURL,
                ProductStatus = updateProductDto.ProductStatus
            };

            _productService.UpdatewS(product);

            return Ok("Ürün güncellendi");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int ID)
        {
            var value = _productService.GetByIDwS(ID);

            _productService.DeletewS(value);

            return Ok("Ürün silindi");
        }
    }
}

