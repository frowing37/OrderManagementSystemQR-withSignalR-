namespace SignalRWebUI.Models.Dto_s.FileDto;

public class SingleFileDto
{
    public string Filename { get; set; }
    
    public IFormFile File { get; set; }
}