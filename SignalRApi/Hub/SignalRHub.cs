using SignalR_Business.Abstract;

namespace SignalRApi.Hub;

using Microsoft.AspNetCore.SignalR;

public class SignalRHub : Hub
{
     private readonly IProductService _productService;
     private readonly ICategoryService _categoryService;
     private readonly IOrderService _orderService;
     private readonly IMoneyCaseService _moneyCaseService;
     private readonly IMenuTableService _menuTableService;
     private readonly IBookingService _bookingService;

     public SignalRHub(IProductService productService,
          ICategoryService categoryService,
          IOrderService orderService,
          IMoneyCaseService moneyCaseService,
          IBookingService bookingService,
          IMenuTableService menuTableService)
     {
          _productService = productService;
          _categoryService = categoryService;
          _orderService = orderService;
          _moneyCaseService = moneyCaseService;
          _bookingService = bookingService;
          _menuTableService = menuTableService;
     }

     public async Task SendStatistics()
     {
          var value = _categoryService.getCategoryCountwS();
          await Clients.All.SendAsync("ReceiveCategoryCount", value);
          
          var value2 = _productService.getProductCountwS();
          await Clients.All.SendAsync("ReceiveProductCount", value2);

          var value3 = _categoryService.getActiveCategoryCountwS();
          await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

          var value4 = _categoryService.getPassiveCategoryCountwS();
          await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

          var value5 = _productService.getProductCountCategoryByBurgerwS();
          await Clients.All.SendAsync("ReceiveProductCountCategoryByBurger", value5);

          var value6 = _productService.getProductCountCategoryByDrinkwS();
          await Clients.All.SendAsync("ReceiveProductCountCategoryByDrink", value6);

          var value7 = _productService.getProductPriceAveragewS();
          await Clients.All.SendAsync("ReceiveProductPriceAverage", value7.ToString("0.00") + "₺");

          var value8 = _productService.getProductByMinPricewS();
          await Clients.All.SendAsync("ReceiveProductByMinPrice", value8);
          
          var value9 = _productService.getProductByMaxPricewS();
          await Clients.All.SendAsync("ReceiveProductByMaxPrice", value9);

          var value10 = _productService.getBurgerAveragePricewS();
          await Clients.All.SendAsync("ReceiveBurgerAveragePrice", value10.ToString("0.00") + "₺");
          
          var value11 = _productService.getDrinkAveragePricewS();
          await Clients.All.SendAsync("ReceiveDrinkAveragePrice", value11.ToString("0.00") + "₺");

          var value12 = _orderService.TotalOrderCountwS();
          await Clients.All.SendAsync("ReceiveTotalOrderCount", value12);

          var value13 = _orderService.LastOrderPrice();
          await Clients.All.SendAsync("ReceiveLastOrderPrice", value13.ToString("0.00") + "₺");

          var value14 = _orderService.ActiveOrderCountwS();
          await Clients.All.SendAsync("ReceiveActiveOrderCount", value14);

          var value15 = _moneyCaseService.TotalMoneyCaseAmountwS();
          await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value15);

          var value16 = _menuTableService.getMenuTableCountwS();
          await Clients.All.SendAsync("ReceiveMenuTableCount", value16);
          
     }

     public async Task ProgressBar()
     {
          var value = _moneyCaseService.TotalMoneyCaseAmountwS();
          await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount2", value.ToString() + "₺");

          var value2 = _menuTableService.getMenuTableCountwS();
          await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount2", value2);

          var value3 = _orderService.ActiveOrderCountwS();
          await Clients.All.SendAsync("ReceiveActiveOrderCount2", value3);
     }

     public async Task GetBookingList()
     {
          var values = _bookingService.GetListAllwS();
          await Clients.All.SendAsync("ReceiveBookingList", values);
     }
}