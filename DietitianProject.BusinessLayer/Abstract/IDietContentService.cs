using DietitianProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.Abstract
{
    public interface IDietContentService:IGenericService<DietContent>
    {
        List<DietContent> TGetByStatus(bool status);
        List<DietContent> TGetListWithUser();
        void TChangeDietContentStatusToTrue(int id);
        void TChangeDietContentStatusToFalse(int id);
    }
}
