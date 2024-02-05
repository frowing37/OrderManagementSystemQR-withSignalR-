using SignalR_DataAccess.Concrete;
using SignalR_Business.Abstract;
using SignalR_Business.Concrete;
using SignalR_DataAccess.Abstract;
using SignalR_DataAccess.EntityFramework;
using System.Reflection;
using SignalR_Entities.Concrete;
using SignalRApi.Hub;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
    });
});

builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IAboutService,AboutManager>();
builder.Services.AddScoped<IAboutDAL, efAbout>();
builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingDAL, efBooking>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDAL, efCategory>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDAL, efContact>();
builder.Services.AddScoped<IDiscountService, DiscountManager>();
builder.Services.AddScoped<IDiscountDAL, efDiscount>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();
builder.Services.AddScoped<IFeatureDAL, efFeature>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDAL, efProduct>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDAL, efSocialMedia>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialDAL, efTestimonial>();
builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IOrderDAL, efOrder>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();
builder.Services.AddScoped<IOrderDetailDAL, efOrderDetail>();
builder.Services.AddScoped<IMoneyCaseService, MoneyCaseManager>();
builder.Services.AddScoped<IMoneyCaseDAL, efMoneyCase>();
builder.Services.AddScoped<IMenuTableService, MenuTableManager>();
builder.Services.AddScoped<IMenuTableDAL, efMenuTable>();
builder.Services.AddScoped<IBasketService, BasketManager>();
builder.Services.AddScoped<IBasketDAL, efBasket>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/SignalRHub");

app.Run();

