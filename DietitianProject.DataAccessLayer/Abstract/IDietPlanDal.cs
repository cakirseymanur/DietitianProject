using DietitianProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.DataAccessLayer.Abstract
{
    public interface IDietPlanDal:IGenericDal<DietPlan>
    {
        void ChangeDietPlanStatusToTrue(int id);
        void ChangeDietPlanStatusToFalse(int id);
        List<DietPlan> GetByStatus(bool status);
    }
}
