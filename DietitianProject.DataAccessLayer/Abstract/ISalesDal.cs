using DietitianProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.DataAccessLayer.Abstract
{
    public interface ISalesDal:IGenericDal<Sale>
    {
        List<DietPlan> GetMyDietPlans(int id);
    }
}
