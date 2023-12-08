using System;
using SignalR_Business.Abstract;
using SignalR_Entities.Concrete;
using SignalR_DataAccess.Abstract;

namespace SignalR_Business.Concrete
{
    public class AboutManager : IAboutService
    {
        protected readonly IAboutDAL _aboutDAL;

        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }

        public void AddwS(About t)
        {
            _aboutDAL.Insert(t);
        }

        public void DeletewS(About t)
        {
            _aboutDAL.Delete(t);
        }

        public About GetByIDwS(int ID)
        {
            return _aboutDAL.GetByID(ID);
        }

        public List<About> GetListAllwS()
        {
            return _aboutDAL.GetListAll();
        }

        public void UpdatewS(About t)
        {
            _aboutDAL.Update(t);
        }
    }
}

