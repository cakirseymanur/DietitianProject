using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.DataAccessLayer.Abstract;
using DietitianProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.Concrete
{
    public class DietPlanManager : IDietPlanService
    {
        IDietPlanDal _dietPlanDal;

        public DietPlanManager(IDietPlanDal dietPlanDal)
        {
            _dietPlanDal = dietPlanDal;
        }

        public void TChangeDietPlanStatusToFalse(int id)
        {
            _dietPlanDal.ChangeDietPlanStatusToFalse(id);
        }

        public void TChangeDietPlanStatusToTrue(int id)
        {
            _dietPlanDal.ChangeDietPlanStatusToTrue(id);
        }

        public void TDelete(DietPlan t)
        {
            _dietPlanDal.Delete(t);
        }

        public DietPlan TGetById(int id)
        {
           return _dietPlanDal.GetById(id);
        }

        public List<DietPlan> TGetByStatus(bool status)
        {
            return _dietPlanDal.GetByStatus(status);
        }

        public List<DietPlan> TGetList()
        {
            return _dietPlanDal.GetList();
        }

        public void TInsert(DietPlan t)
        {
            _dietPlanDal.Insert(t);
        }

        public void TUpdate(DietPlan t)
        {
            _dietPlanDal.Update(t);
        }
    }
}
