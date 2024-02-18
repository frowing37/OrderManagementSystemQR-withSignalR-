namespace SignalRWebUI.Models.Dtos.MessageDto;

public class GetMessageDto
{
    public int MessageID { get; set; }
    
    public string NameSurname { get; set; }
    
    public string Mail { get; set; }
    
    public string Phone { get; set; }
    
    public string Subject { get; set; }
    
    public string MessageContent { get; set; }
    
    public DateTime MessageSendDate { get; set; }
}