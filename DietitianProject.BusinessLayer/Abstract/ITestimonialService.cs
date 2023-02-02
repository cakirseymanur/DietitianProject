using DietitianProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.Abstract
{
    public interface ITestimonialService : IGenericService<Testimonial>
    {
        List<Testimonial> TGetByStatus(bool status);
    }
}
