using System;
using SignalR_DataAccess.Repositories;
using SignalR_DataAccess.Abstract;
using SignalR_Entities.Concrete;
using SignalR_DataAccess.Concrete;

namespace SignalR_DataAccess.EntityFramework
{
    public class efFeature : GenericRepository<Feature>, IFeatureDAL
    {
        public efFeature(SignalRContext context) : base(context)
        {
        }
    }
}

