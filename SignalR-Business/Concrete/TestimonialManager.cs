using System;
using SignalR_Business.Abstract;
using SignalR_DataAccess.Abstract;
using SignalR_Entities.Concrete;

namespace SignalR_Business.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        protected readonly ITestimonialDAL _testimonialDAL;

        public TestimonialManager(ITestimonialDAL testimonialDAL)
        {
            _testimonialDAL = testimonialDAL;
        }

        public void AddwS(Testimonial t)
        {
            _testimonialDAL.Insert(t);
        }

        public void DeletewS(Testimonial t)
        {
            _testimonialDAL.Delete(t);
        }

        public Testimonial GetByIDwS(int ID)
        {
            return _testimonialDAL.GetByID(ID);
        }

        public List<Testimonial> GetListAllwS()
        {
            return _testimonialDAL.GetListAll();
        }

        public void UpdatewS(Testimonial t)
        {
            _testimonialDAL.Update(t);
        }
    }
}

