using SignalR_Entities.Concrete;

namespace SignalR_Business.Abstract;

public interface IMoneyCaseService : IGenericService<MoneyCase>
{
    decimal TotalMoneyCaseAmountwS();
}