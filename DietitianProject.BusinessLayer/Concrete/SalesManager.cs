using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.DataAccessLayer.Abstract;
using DietitianProject.DataAccessLayer.UnitOfWork;
using DietitianProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.Concrete
{
    public class SalesManager : ISalesService
    {
        private readonly ISalesDal _salesDal;
        private readonly IUowDal _uowDal;

        public SalesManager(ISalesDal salesDal, IUowDal uowDal)
        {
            _salesDal = salesDal;
            _uowDal = uowDal;
        }

        public void TDelete(Sale t)
        {
            _salesDal.Delete(t);
            //_uowDal.Save();
        }

        public Sale TGetById(int id)
        {
            return _salesDal.GetById(id);
        }

        public List<Sale> TGetList()
        {
            return _salesDal.GetList();
        }

        public List<DietPlan> TGetMyDietPlans(int id)
        {
            return _salesDal.GetMyDietPlans(id);
        }

        public void TInsert(Sale t)
        {
            _salesDal.Insert(t);
            //_uowDal.Save();
        }

        public void TUpdate(Sale t)
        {
            _salesDal.Update(t);
            //_uowDal.Save();
        }
    }
}
