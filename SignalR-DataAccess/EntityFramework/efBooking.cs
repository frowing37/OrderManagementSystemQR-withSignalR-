using System;
using SignalR_DataAccess.Abstract;
using SignalR_DataAccess.Concrete;
using SignalR_DataAccess.Repositories;
using SignalR_Entities.Concrete;

namespace SignalR_DataAccess.EntityFramework
{
    public class efBooking : GenericRepository<Booking>, IBookingDAL
    {
        public efBooking(SignalRContext context) : base(context)
        {
        }
    }
}

