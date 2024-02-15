namespace SignalRWebUI.Models.Dtos.UserDto;

public class RegisterDto
{
    public string Name { get; set; }

    public string? SecondName { get; set; }

    public string Surname { get; set; }

    public string PhoneNumber { get; set; }

    public string Mail { get; set; }

    public string Password { get; set; }
    
    public int ConfirmCod { get; set; }
}