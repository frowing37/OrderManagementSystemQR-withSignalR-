using SignalR_DataAccess.Abstract;
using SignalR_DataAccess.Concrete;
using SignalR_DataAccess.Repositories;
using SignalR_Entities.Concrete;

namespace SignalR_DataAccess.EntityFramework;

public class efMoneyCase : GenericRepository<MoneyCase>, IMoneyCaseDAL
{
    public efMoneyCase(SignalRContext context) : base(context)
    {
    }

    public decimal TotalMoneyCaseAmount()
    {
        using var context = new SignalRContext();
        return context.MoneyCases.Select(m => m.TotalAmount).FirstOrDefault();
    }
}