using SignalR_DataAccess.Concrete;

namespace SignalRApi.Hub;

using Microsoft.AspNetCore.SignalR;

public class SignalRHub : Hub
{
     private SignalRContext context = new SignalRContext();

     public async Task SendCategoryCount()
     {
          var value = context.Categories.Count();
          await Clients.All.SendAsync("ReceiveCategoryCount", value);
     }
}