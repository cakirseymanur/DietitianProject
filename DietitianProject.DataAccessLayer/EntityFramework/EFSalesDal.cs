using DietitianProject.DataAccessLayer.Abstract;
using DietitianProject.DataAccessLayer.Concrete;
using DietitianProject.DataAccessLayer.Repository;
using DietitianProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.DataAccessLayer.EntityFramework
{
    public class EFSalesDal : GenericRepository<Sale>, ISalesDal
    {
        public List<DietPlan> GetMyDietPlans(int id)
        {
            using (var context = new Context())
            {
                List<int> sale = context.Sales.Where(x => x.AppUserId==id).Select(i =>i.DietPlanId).ToList();
                List<DietPlan> plans = new List<DietPlan>();
                foreach (var item in sale)
                {
                    var bisey = context.DietPlans.FirstOrDefault(x => x.Id == item);
                    plans.Add(bisey);
                }
                return plans;
            }
        }
    }
}
