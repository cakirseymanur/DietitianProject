using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.DataAccessLayer.Abstract;
using DietitianProject.DataAccessLayer.UnitOfWork;
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
        private readonly ITestimonialDal _testimonialDal;
        private readonly IUowDal _uowDal;

        public TestimonialManager(ITestimonialDal testimonialDal, IUowDal uowDal)
        {
            _testimonialDal = testimonialDal;
            _uowDal = uowDal;
        }

        public void TChangeTestimonialStatusToFalse(int id)
        {
            _testimonialDal.ChangeTestimonialStatusToFalse(id);
            _uowDal.Save();
        }

        public void TChangeTestimonialStatusToTrue(int id)
        {
            _testimonialDal.ChangeTestimonialStatusToTrue(id);
            _uowDal.Save();
        }

        public void TDelete(Testimonial t)
        {
            _testimonialDal.Delete(t);
            _uowDal.Save();
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
            _uowDal.Save();
        }

        public void TUpdate(Testimonial t)
        {
            _testimonialDal.Update(t);
            _uowDal.Save();
        }
    }
}
