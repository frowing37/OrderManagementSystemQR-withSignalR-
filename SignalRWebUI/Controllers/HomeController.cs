using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR_Entities.Concrete;
using SignalRWebUI.Models.Dtos.UserDto;

namespace SignalRWebUI.Controllers;

public class HomeController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    
    public HomeController(UserManager<AppUser> userManager,
                          SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult noContent()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        if (user == null)
        {
            return RedirectToAction("Error", "Home");
        }
        else
        {
            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
            
            if (result.Succeeded)
            {
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    var redirectUrl = "/Category/Index";

                    return Json(new { redirectUrl });
                }
                else
                {
                    var redirectUrl = "/Customer/Index";

                    return Json(new { redirectUrl });
                }
            
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var user = await _userManager.FindByEmailAsync(registerDto.Mail);

        if (user != null)
        {
            return RedirectToAction("Error", "Home");
        }
        else
        {
            AppUser newUser = new AppUser()
            {
                UserName = registerDto.Name + registerDto.Surname[0],
                Name = registerDto.Name,
                SecondName = registerDto.SecondName,
                Surname = registerDto.Surname,
                PhoneNumber = registerDto.PhoneNumber,
                Email = registerDto.Mail,
                Mail = registerDto.Mail,
                Password = registerDto.Password
            };

            var passwordHasher = new PasswordHasher<AppUser>();
            newUser.PasswordHash = passwordHasher.HashPassword(newUser, newUser.Password);

            var result = await _userManager.CreateAsync(newUser);

            if (result.Succeeded)
            {
                var admins = await _userManager.GetUsersInRoleAsync("Admin");

                if (admins.Count <= 5)
                {
                    await _userManager.AddToRoleAsync(newUser, "Admin");
                    await _signInManager.SignInAsync(newUser, true);
                    
                    var redirectUrl = "/Category/Index";

                    return Json(new { redirectUrl });
                }
                else
                {
                    await _userManager.AddToRoleAsync(newUser, "Customer");
                    await _signInManager.SignInAsync(newUser, true);
                    
                    var redirectUrl = "/Customer/Index";

                    return Json(new { redirectUrl });
                }
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Error(string errorString)
    {
        ViewBag.Error = errorString;

        return View();
    }

    public IActionResult Logout()
    {
        _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Customer");
    }

    public IActionResult UserSettings()
    {
        return View();
    }
    
    public IActionResult SignUpIn()
    {
        return View();
    }
}

