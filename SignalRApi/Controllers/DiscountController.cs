﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR_Business.Abstract;
using SignalR_Dto.DiscountDto;
using SignalR_Entities.Concrete;
using AutoMapper;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    public class DiscountController : Controller
    {
        protected readonly IDiscountService _discountService;
        protected readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.GetListAllwS());

            return Ok(values);
        }

        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int ID)
        {
            var value = _discountService.GetByIDwS(ID);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            Discount discount = new Discount()
            {
                DiscountID = updateDiscountDto.DiscountID,
                Title = updateDiscountDto.Title,
                Amount = updateDiscountDto.Amount,
                Description = updateDiscountDto.Description,
                ImageURL = updateDiscountDto.ImageURL
            };

            _discountService.UpdatewS(discount);

            return Ok("İndirim güncellendi");
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            Discount discount = new Discount()
            {
                Title = createDiscountDto.Title,
                Amount = createDiscountDto.Amount,
                Description = createDiscountDto.Description,
                ImageURL = createDiscountDto.ImageURL
            };

            _discountService.AddwS(discount);

            return Ok("İndirim oluşturuldu");
        }

        [HttpDelete]
        public IActionResult DeleteDiscount(int ID)
        {
            var value = _discountService.GetByIDwS(ID);

            _discountService.DeletewS(value);

            return Ok("İndirim silindi");
        }
    }
}

