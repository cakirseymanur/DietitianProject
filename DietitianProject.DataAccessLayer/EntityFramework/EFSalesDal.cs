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
    public class EFSalesDal : GenericRepository<Sale>, ISalesDal
    {
        public EFSalesDal(Context context) : base(context)
        {
        }

        public List<Sale> GetAllSaleInfo()
        {
            using (var context = new Context())
            {
                List<Sale> sale = context.Sales.Include(x => x.AppUser).Include(x=>x.DietPlan).ToList();
                
                return sale;
            }
        }

        public List<Sale> GetMyDietPlans(int id)
        {
            using (var context = new Context())
            {
                List<Sale> sale = context.Sales.Include(x => x.AppUser).Include(x => x.DietPlan).Where(i=>i.AppUserId==id).ToList();

                return sale;
            }
        }
    }
}
