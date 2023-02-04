using DietitianProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=DbDietitian;integrated security=True");
        }

        public DbSet<DietitianInfo> DietitianInfos { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<DietPlan> DietPlans { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
