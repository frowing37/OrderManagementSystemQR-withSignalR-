using Microsoft.AspNetCore.Mvc;
using SignalR_Business.Abstract;
using SignalR_Entities.Concrete;
using SignalRWebUI.Models.Dtos.NotificationDto;

namespace SignalRApi.Controllers;

[Route("api/[controller]")]
public class NotificationController : Controller
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet("CountByStatusFalse")]
    public IActionResult GetNotificationCountByStatusFalse()
    {
        var value = _notificationService.getNotificationCountByStatusFalsewS();

        return Ok(value);
    }

    [HttpGet("{ID}")]
    public IActionResult GetNotification(int ID)
    {
        var value = _notificationService.GetByIDwS(ID);

        return Ok(value);
    }

    [HttpGet("NotificationList")]
    public IActionResult NotificationsList()
    {
        var value = _notificationService.GetListAllwS();

        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateNotification([FromBody] CreateNotificationDto createNotificationDto)
    {
        Notification notification = new Notification()
        {
            Type = createNotificationDto.Type,
            Icon = createNotificationDto.Icon,
            Description = createNotificationDto.Description,
            Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
            Status = createNotificationDto.Status
        };
        
        _notificationService.AddwS(notification);

        return Ok("Bildirim Oluşturuldu");
    }

    [HttpPut]
    public IActionResult UpdateNotification([FromBody] UpdateNotificationDto updateNotificationDto)
    {
        Notification notification = new Notification()
        {
            Type = updateNotificationDto.Type,
            Icon = updateNotificationDto.Icon,
            Description = updateNotificationDto.Description,
            Date = updateNotificationDto.Date,
            Status = updateNotificationDto.Status
        };
        
        _notificationService.UpdatewS(notification);

        return Ok("Bildirim Güncellendi");
    }

    [HttpDelete("{ID}")]
    public IActionResult DeleteNotification(int ID)
    {
        var value = _notificationService.GetByIDwS(ID);
        
        _notificationService.DeletewS(value);

        return Ok("Bildirim Silindi");
    }
}