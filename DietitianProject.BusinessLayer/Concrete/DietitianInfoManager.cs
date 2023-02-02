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
    public class DietitianInfoManager: IDietitianInfoService
    {
        IDietitianInfoDal _dietitianInfoDal;

        public DietitianInfoManager(IDietitianInfoDal dietitianInfoDal)
        {
            _dietitianInfoDal = dietitianInfoDal;
        }

        public void TDelete(DietitianInfo t)
        {
            _dietitianInfoDal.Delete(t);
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
        }

        public void TUpdate(DietitianInfo t)
        {
            _dietitianInfoDal.Update(t);
        }
    }
}
