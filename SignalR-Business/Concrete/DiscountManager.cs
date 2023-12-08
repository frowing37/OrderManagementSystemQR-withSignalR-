using System;
using SignalR_Business.Abstract;
using SignalR_DataAccess.Abstract;
using SignalR_Entities.Concrete;

namespace SignalR_Business.Concrete
{
    public class DiscountManager : IDiscountService
    {
        protected readonly IDiscountDAL _discountDAL;

        public DiscountManager(IDiscountDAL discountDAL)
        {
            _discountDAL = discountDAL;
        }

        public void AddwS(Discount t)
        {
            _discountDAL.Insert(t);
        }

        public void DeletewS(Discount t)
        {
            _discountDAL.Delete(t);
        }

        public Discount GetByIDwS(int ID)
        {
            return _discountDAL.GetByID(ID);
        }

        public List<Discount> GetListAllwS()
        {
            return _discountDAL.GetListAll();
        }

        public void UpdatewS(Discount t)
        {
            _discountDAL.Update(t);
        }
    }
}

