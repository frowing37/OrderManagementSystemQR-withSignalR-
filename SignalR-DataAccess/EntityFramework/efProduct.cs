using System;
using SignalR_Entities.Concrete;
using SignalR_DataAccess.Abstract;
using SignalR_DataAccess.Repositories;
using SignalR_DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;

namespace SignalR_DataAccess.EntityFramework
{
    public class efProduct : GenericRepository<Product>, IProductDAL
    {
        public efProduct(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductswithCategories()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList();

            return values;
        }
    }
}

