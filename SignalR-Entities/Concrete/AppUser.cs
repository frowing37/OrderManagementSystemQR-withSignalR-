using Microsoft.AspNetCore.Identity;

namespace SignalR_Entities.Concrete;

public class AppUser : IdentityUser<int>
{
    public string Name { get; set; }

    public string? SecondName { get; set; }

    public string Surname { get; set; }

    public string PhoneNumber { get; set; }

    public string Mail { get; set; }

    public string Password { get; set; }
    
    public string ImageURL { get; set; }
    
    public int ConfirmCod { get; set; }
}