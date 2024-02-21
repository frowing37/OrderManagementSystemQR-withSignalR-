using Microsoft.EntityFrameworkCore;
using SignalR_DataAccess.Abstract;
using SignalR_DataAccess.Concrete;
using SignalR_DataAccess.Repositories;
using SignalR_Entities.Concrete;

namespace SignalR_DataAccess.EntityFramework;

public class efBasket : GenericRepository<Basket>, IBasketDAL
{
    public efBasket(SignalRContext context) : base(context)
    {
    }

    public List<Basket> getBasketByMenuTable(int ID)
    {
        using var context = new SignalRContext();
        var values = context.Baskets.Where(x => x.MenuTableID == ID)
            .Include(y=>y.Product).ToList();
        
        return values;
    }
}