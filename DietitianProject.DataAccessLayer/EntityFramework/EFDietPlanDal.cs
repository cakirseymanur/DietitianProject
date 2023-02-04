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
    public class EFDietPlanDal : GenericRepository<DietPlan>, IDietPlanDal
    {
        public void ChangeDietPlanStatusToFalse(int id)
        {
            using (var context = new Context())
            {
                var values = context.DietPlans.Find(id);
                values.Status = false;
            }
        }

        public void ChangeDietPlanStatusToTrue(int id)
        {
            using (var context = new Context())
            {
                var values = context.DietPlans.Find(id);
                values.Status = true;
            }
        }
        public List<DietPlan> GetByStatus(bool status)
        {
            using (var context = new Context())
            {
                var values= context.DietPlans.Where(x=>x.Status==status).ToList();
                return values;
            }
        }
    }
}
