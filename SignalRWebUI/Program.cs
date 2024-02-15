using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using SignalR_DataAccess.Concrete;
using SignalR_Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<SignalRContext>()
    .AddDefaultTokenProviders();
builder.Services.AddHttpClient();
//builder.Services.AddScoped<UserManager<AppUser>>();
//builder.Services.AddScoped<RoleManager<AppUser>>();
//builder.Services.AddScoped<SignInManager<AppUser>>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Home/Login";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}");

//Identity Rollerinin eklenmesi
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    var context = services.GetRequiredService<SignalRContext>();

    //Tanımlanan rollerin veri tabanına eklenmesi
    if (!context.Roles.Any())
    {
        var adminRole = new AppRole { Name = "Admin" };
        var customerRole = new AppRole { Name = "Customer" };

        roleManager.CreateAsync(adminRole).Wait();
        roleManager.CreateAsync(customerRole).Wait();
    }
}

app.Run();

