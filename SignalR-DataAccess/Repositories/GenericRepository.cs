using System;
using SignalR_DataAccess.Abstract;
using SignalR_DataAccess.Concrete;

namespace SignalR_DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericDAL<T> where T : class
    {
        private readonly SignalRContext _context;

        public GenericRepository(SignalRContext context)
        {
            _context = context;
        }

        public void Delete(T t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }

        public T GetByID(int ID)
        {
            return _context.Set<T>().Find(ID);
        }

        public List<T> GetListAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            _context.Add(t);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }
    }
}

