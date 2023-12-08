using System;
using SignalR_Business.Abstract;
using SignalR_DataAccess.Abstract;
using SignalR_Entities.Concrete;

namespace SignalR_Business.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        protected readonly ISocialMediaDAL _socialMediaDAL;

        public SocialMediaManager(ISocialMediaDAL socialMediaDAL)
        {
            _socialMediaDAL = socialMediaDAL;
        }

        public void AddwS(SocialMedia t)
        {
            _socialMediaDAL.Insert(t);
        }

        public void DeletewS(SocialMedia t)
        {
            _socialMediaDAL.Delete(t);
        }

        public SocialMedia GetByIDwS(int ID)
        {
            return _socialMediaDAL.GetByID(ID);
        }

        public List<SocialMedia> GetListAllwS()
        {
            return _socialMediaDAL.GetListAll();
        }

        public void UpdatewS(SocialMedia t)
        {
            _socialMediaDAL.Update(t);
        }
    }
}

