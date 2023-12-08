using System;
using SignalR_Entities.Concrete;
using SignalR_DataAccess.Abstract;
using SignalR_DataAccess.Repositories;
using SignalR_DataAccess.Concrete;

namespace SignalR_DataAccess.EntityFramework
{
    public class efSocialMedia : GenericRepository<SocialMedia>, ISocialMediaDAL
    {
        public efSocialMedia(SignalRContext context) : base(context)
        {
        }
    }
}

