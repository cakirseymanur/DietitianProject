using DietitianProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.Abstract
{
    public interface IDietPlanService:IGenericService<DietPlan>
    {
        List<DietPlan> TGetByStatus(bool status);
        void TChangeDietPlanStatusToTrue(int id);
        void TChangeDietPlanStatusToFalse(int id);
    }
}
