using Microsoft.AspNetCore.Mvc;
using SignalR_Business.Abstract;

namespace SignalRApi.Controllers;

[Route("api/[controller]")]
public class NotificationController : Controller
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public IActionResult GetNotificationCountByStatusFalse()
    {
        var value = _notificationService.getNotificationCountByStatusFalsewS();

        return Ok(value);
    }
}