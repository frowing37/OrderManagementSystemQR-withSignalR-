using System;
using SignalR_Business.Abstract;
using SignalR_Entities.Concrete;
using SignalR_DataAccess.Abstract;

namespace SignalR_Business.Concrete
{
    public class ContactManager : IContactService
    {
        protected readonly IContactDAL _contactDAL;

        public ContactManager(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public void AddwS(Contact t)
        {
            _contactDAL.Insert(t);
        }

        public void DeletewS(Contact t)
        {
            _contactDAL.Delete(t);
        }

        public Contact GetByIDwS(int ID)
        {
            return _contactDAL.GetByID(ID);
        }

        public List<Contact> GetListAllwS()
        {
            return _contactDAL.GetListAll();
        }

        public void UpdatewS(Contact t)
        {
            _contactDAL.Update(t);
        }
    }
}

