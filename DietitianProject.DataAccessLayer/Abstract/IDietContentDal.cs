using DietitianProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.DataAccessLayer.Abstract
{
    public interface IDietContentDal : IGenericDal<DietContent>
    {
        List<DietContent> GetByStatus(bool status);
        List<DietContent> GetListWithUser();
        void ChangeDietContentStatusToTrue(int id);
        void ChangeDietContentStatusToFalse(int id);
    }
}
