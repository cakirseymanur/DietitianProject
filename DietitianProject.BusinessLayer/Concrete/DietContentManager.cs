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
    public class DietContentManager : IDietContentService
    {
        private readonly IDietContentDal _dietContent;
        private readonly IUowDal _uowDal;

        public DietContentManager(IDietContentDal dietContent, IUowDal uowDal)
        {
            _dietContent = dietContent;
            _uowDal = uowDal;
        }

        public void TDelete(DietContent t)
        {
            _dietContent.Delete(t);
            _uowDal.Save();
        }

        public DietContent TGetById(int id)
        {
            return _dietContent.GetById(id);
        }

        public List<DietContent> TGetList()
        {
            return _dietContent.GetList();
        }

        public void TInsert(DietContent t)
        {
            _dietContent.Insert(t);
            _uowDal.Save();
        }

        public void TUpdate(DietContent t)
        {
            _dietContent.Update(t);
            _uowDal.Save();
        }
    }
}
