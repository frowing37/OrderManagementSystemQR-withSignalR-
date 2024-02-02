using SignalR_Business.Abstract;
using SignalR_DataAccess.Abstract;
using SignalR_Entities.Concrete;

namespace SignalR_Business.Concrete;

public class MoneyCaseManager :  IMoneyCaseService
{
    private readonly IMoneyCaseDAL _moneyCaseDal;

    public MoneyCaseManager(IMoneyCaseDAL moneyCaseDal)
    {
        _moneyCaseDal = moneyCaseDal;
    }

    public void AddwS(MoneyCase t)
    {
        _moneyCaseDal.Insert(t);
    }

    public void UpdatewS(MoneyCase t)
    {
        _moneyCaseDal.Update(t);
    }

    public void DeletewS(MoneyCase t)
    {
        _moneyCaseDal.Delete(t);
    }

    public MoneyCase GetByIDwS(int ID)
    {
        return _moneyCaseDal.GetByID(ID);
    }

    public List<MoneyCase> GetListAllwS()
    {
        return _moneyCaseDal.GetListAll();
    }

    public decimal TotalMoneyCaseAmountwS()
    {
        return _moneyCaseDal.TotalMoneyCaseAmount();
    }
}