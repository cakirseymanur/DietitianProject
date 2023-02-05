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
    public class DietitianInfoManager: IDietitianInfoService
    {
        private readonly IDietitianInfoDal _dietitianInfoDal;
        private readonly IUowDal _uowDal;

        public DietitianInfoManager(IDietitianInfoDal dietitianInfoDal, IUowDal uowDal)
        {
            _dietitianInfoDal = dietitianInfoDal;
            _uowDal = uowDal;
        }

        public void TDelete(DietitianInfo t)
        {
            _dietitianInfoDal.Delete(t);
            //_uowDal.Save();
        }

        public DietitianInfo TGetById(int id)
        {
            return _dietitianInfoDal.GetById(id);
        }

        public List<DietitianInfo> TGetList()
        {
            return _dietitianInfoDal.GetList();
        }

        public void TInsert(DietitianInfo t)
        {
            _dietitianInfoDal.Insert(t);
            //_uowDal.Save();
        }

        public void TUpdate(DietitianInfo t)
        {
            _dietitianInfoDal.Update(t);
            //_uowDal.Save();
        }
    }
}
