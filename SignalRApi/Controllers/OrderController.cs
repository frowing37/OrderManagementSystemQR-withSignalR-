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
        private readonly OrderManager _orderManager;

        public OrderController(OrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        
        [HttpGet("TotalOrderCount")]
        public IActionResult GetTotalOrderCount()
        {
            var count = _orderManager.TotalOrderCountwS();

            return Ok(count);
        }
        
        [HttpGet("ActiveOrderCount")]
        public IActionResult GetActiveOrderCount()
        {
            var count = _orderManager.ActiveOrderCountwS();

            return Ok(count);
        }
    
    }
    
}

