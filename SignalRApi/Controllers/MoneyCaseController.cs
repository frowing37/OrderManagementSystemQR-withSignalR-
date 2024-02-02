using Microsoft.AspNetCore.Mvc;
using SignalR_Business.Abstract;
using SignalR_Business.Concrete;

namespace SignalRApi.Controllers;

[Route("api/[controller]")]
public class MoneyCaseController : Controller
{
    private readonly IMoneyCaseService _moneyCaseService;

    public MoneyCaseController(IMoneyCaseService moneyCaseService)
    {
        _moneyCaseService = moneyCaseService;
    }

    [HttpGet("TotalMoneyCaseAmount")]
    public IActionResult TotalMoneyCaseAmountwS()
    {
        var value = _moneyCaseService.TotalMoneyCaseAmountwS();

        return Ok(value);
    }
}