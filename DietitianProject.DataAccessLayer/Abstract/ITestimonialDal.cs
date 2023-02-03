using DietitianProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.DataAccessLayer.Abstract
{
    public interface ITestimonialDal : IGenericDal<Testimonial>
    {
        List<Testimonial> GetByStatus(bool status);
        List<Testimonial> GetListWithUser();
        void ChangeTestimonialStatusToTrue(int id);
        void ChangeTestimonialStatusToFalse(int id);
    }
}
