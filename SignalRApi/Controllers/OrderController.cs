using Microsoft.AspNetCore.Mvc;
using SignalR_Business.Abstract;
using SignalR_Dto.FeatureDto;
using SignalR_Entities.Concrete;
using AutoMapper;
using SignalR_Business.Concrete;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [HttpGet("TotalOrderCount")]
        public IActionResult GetTotalOrderCount()
        {
            var count = _orderService.TotalOrderCountwS();

            return Ok(count);
        }
        
        [HttpGet("ActiveOrderCount")]
        public IActionResult GetActiveOrderCount()
        {
            var count = _orderService.ActiveOrderCountwS();

            return Ok(count);
        }
        
        [HttpGet("LastOrderPrice")]
        public IActionResult GetLastOrderPrice()
        {
            var count = _orderService.LastOrderPrice();

            return Ok(count);
        }
    
    }
    
}

