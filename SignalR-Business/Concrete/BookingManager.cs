using System;
using SignalR_DataAccess.Abstract;
using SignalR_Business.Abstract;
using SignalR_Entities.Concrete;

namespace SignalR_Business.Concrete
{
    public class BookingManager : IBookingService
    {
        protected readonly IBookingDAL _bookingDAL;

        public BookingManager(IBookingDAL bookingDAL)
        {
            _bookingDAL = bookingDAL;
        }

        public void AddwS(Booking t)
        {
            _bookingDAL.Insert(t);
        }

        public void DeletewS(Booking t)
        {
            _bookingDAL.Delete(t);
        }

        public Booking GetByIDwS(int ID)
        {
            return _bookingDAL.GetByID(ID);
        }

        public List<Booking> GetListAllwS()
        {
            return _bookingDAL.GetListAll();
        }

        public void UpdatewS(Booking t)
        {
            _bookingDAL.Update(t);
        }
    }
}

