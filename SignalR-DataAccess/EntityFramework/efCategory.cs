﻿using System;
using SignalR_Entities.Concrete;
using SignalR_DataAccess.Abstract;
using SignalR_DataAccess.Repositories;
using SignalR_DataAccess.Concrete;

namespace SignalR_DataAccess.EntityFramework
{
    public class efCategory : GenericRepository<Category>, ICategoryDAL
    {
        public efCategory(SignalRContext context) : base(context)
        {
        }

        public int getCategoryCount()
        {
            using var context = new SignalRContext();
            return context.Categories.Count();
        }

        public int getActiveCategory()
        {
            using var context = new SignalRContext();
            return context.Categories.Where(c => c.Status == true).Count();
        }

        public int getPassiveCategory()
        {
            using var context = new SignalRContext();
            return context.Categories.Where(c => c.Status == false).Count();
        }
    }
}

