using SignalR_Business.Abstract;
using SignalR_DataAccess.Abstract;
using SignalR_Entities.Concrete;

namespace SignalR_Business.Concrete;

public class BasketManager : IBasketService
{
    private readonly IBasketDAL _basketDAL;

    public BasketManager(IBasketDAL basketDal)
    {
        _basketDAL = basketDal;
    }

    public void AddwS(Basket t)
    {
        _basketDAL.Insert(t);
    }

    public void UpdatewS(Basket t)
    {
        _basketDAL.Update(t);
    }

    public void DeletewS(Basket t)
    {
        _basketDAL.Delete(t);
    }

    public Basket GetByIDwS(int ID)
    {
        return _basketDAL.GetByID(ID);
    }

    public List<Basket> GetListAllwS()
    {
        return _basketDAL.GetListAll();
    }

    public List<Basket> getBasketByMenuTablewS(int ID)
    {
        return _basketDAL.getBasketByMenuTable(ID);
    }
}