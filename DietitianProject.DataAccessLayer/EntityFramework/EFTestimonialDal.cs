using DietitianProject.DataAccessLayer.Abstract;
using DietitianProject.DataAccessLayer.Concrete;
using DietitianProject.DataAccessLayer.Repository;
using DietitianProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.DataAccessLayer.EntityFramework
{
    public class EFTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        public List<Testimonial> GetByStatus(bool status)
        {
            using (var context = new Context())
            {
                var values= context.Testimonials.Include(x => x.AppUser).ToList();
                return values.Where(x=>x.Status==status).ToList();
            }
        }
    }
}
