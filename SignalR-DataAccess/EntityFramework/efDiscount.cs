using System;
using Microsoft.EntityFrameworkCore;
using SignalR_Entities.Concrete;
using SignalR_DataAccess.Abstract;
using SignalR_DataAccess.Repositories;
using SignalR_DataAccess.Concrete;

namespace SignalR_DataAccess.EntityFramework
{
    public class efDiscount : GenericRepository<Discount>, IDiscountDAL
    {
        public efDiscount(SignalRContext context) : base(context)
        {
        }

        /*public List<Discount> GetDiscountswithProducts()
        {
            var context = new SignalRContext();
            var values = context.Discounts.Include(x => x.ProductDiscounts).ToList();

            return values;
        }*/

        public List<Discount> GetDiscountswithProduct()
        {
            using var context = new SignalRContext();
            var values = context.Discounts.Include(x => x.Product).ToList();

            return values;
        }
    }
}

