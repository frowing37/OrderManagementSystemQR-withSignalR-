using Microsoft.AspNetCore.Mvc;
using SignalR_Business.Abstract;
using SignalR_Dto.MessageDto;
using SignalR_Entities.Concrete;

namespace SignalRApi.Controllers;

[Route("api/[controller]")]
public class MessageController : Controller
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet]
    public IActionResult MessageList()
    {
        var values = _messageService.GetListAllwS();

        return Ok(values);
    }

    [HttpGet("{ID}")]
    public IActionResult GetMessage(int ID)
    {
        var value = _messageService.GetByIDwS(ID);

        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateMessage([FromBody] CreateMessageDto createMessageDto)
    {
        Message message = new Message()
        {
            NameSurname = createMessageDto.NameSurname,
            Mail = createMessageDto.Mail,
            Phone = createMessageDto.Phone,
            Subject = createMessageDto.Subject,
            MessageContent = createMessageDto.MessageContent,
            MessageSendDate = createMessageDto.MessageSendDate,
        };
        
        _messageService.AddwS(message);

        return Ok("Yeni Mesaj Oluşturuldu");
    }

    [HttpPut]
    public IActionResult UpdateMessage([FromBody] UpdateMessageDto updateMessageDto)
    {
        Message message = new Message()
        {
            NameSurname = updateMessageDto.NameSurname,
            Mail = updateMessageDto.Mail,
            Phone = updateMessageDto.Phone,
            Subject = updateMessageDto.Subject,
            MessageContent = updateMessageDto.MessageContent,
            MessageSendDate = updateMessageDto.MessageSendDate,
        }; 
        
        _messageService.UpdatewS(message);

        return Ok("Mesaj Güncellendi");
    }

    [HttpDelete("{ID}")]
    public IActionResult DeleteMessage(int ID)
    {
        var value = _messageService.GetByIDwS(ID);
        
        _messageService.DeletewS(value);

        return Ok("Mesaj Silindi");
    }
}