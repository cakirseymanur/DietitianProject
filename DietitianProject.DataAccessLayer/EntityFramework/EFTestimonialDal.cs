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
        public void ChangeTestimonialStatusToFalse(int id)
        {
            using (var context = new Context())
            {
                var values = context.Testimonials.Find(id);
                values.Status = false;
                context.SaveChanges();
            }
        }

        public void ChangeTestimonialStatusToTrue(int id)
        {
            using (var context = new Context())
            {
                var values = context.Testimonials.Find(id);
                values.Status = true;
                context.SaveChanges();
            }
        }

        public List<Testimonial> GetByStatus(bool status)
        {
            using (var context = new Context())
            {
                var values= context.Testimonials.Include(x => x.AppUser).ToList();
                return values.Where(x=>x.Status==status).ToList();
            }
        }

        public List<Testimonial> GetListWithUser()
        {
            using (var context = new Context())
            {
                var values = context.Testimonials.Include(x => x.AppUser).ToList();
                return values;
            }
        }
    }
}
