using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.DataAccessLayer.Abstract;
using DietitianProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void TChangeTestimonialStatusToFalse(int id)
        {
            _testimonialDal.ChangeTestimonialStatusToFalse(id);
        }

        public void TChangeTestimonialStatusToTrue(int id)
        {
            _testimonialDal.ChangeTestimonialStatusToTrue(id);
        }

        public void TDelete(Testimonial t)
        {
            _testimonialDal.Delete(t);
        }

        public Testimonial TGetById(int id)
        {
            return _testimonialDal.GetById(id);
        }
         
        public List<Testimonial> TGetByStatus(bool status)
        {
           return _testimonialDal.GetByStatus(status);
        }

        public List<Testimonial> TGetList()
        {
            return _testimonialDal.GetList();
        }

        public List<Testimonial> TGetListWithUser()
        {
            return _testimonialDal.GetListWithUser();
        }

        public void TInsert(Testimonial t)
        {
            _testimonialDal.Insert(t);
        }

        public void TUpdate(Testimonial t)
        {
            _testimonialDal.Update(t);
        }
    }
}
