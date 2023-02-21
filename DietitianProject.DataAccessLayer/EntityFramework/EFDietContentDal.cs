using DietitianProject.DataAccessLayer.Abstract;
using DietitianProject.DataAccessLayer.Concrete;
using DietitianProject.DataAccessLayer.Repository;
using DietitianProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.DataAccessLayer.EntityFramework
{
    public class EFDietContentDal : GenericRepository<DietContent>, IDietContentDal
    {
        public EFDietContentDal(Context context) : base(context)
        {
        }

        public void ChangeDietContentStatusToFalse(int id)
        {
            using (var context = new Context())
            {
                var values = context.DietContents.Find(id);
                values.Status = false;
                context.SaveChanges();
            }
        }

        public void ChangeDietContentStatusToTrue(int id)
        {
            using (var context = new Context())
            {
                var values = context.DietContents.Find(id);
                values.Status = true;
                context.SaveChanges();
            }
        }
     
        List<DietContent> IDietContentDal.GetByStatus(bool status)
        {
            using (var context = new Context())
            {
                var values = context.DietContents.Include(x => x.AppUser).ToList();
                return values.Where(x => x.Status == status).ToList();
            }
        }

        List<DietContent> IDietContentDal.GetListWithUser()
        {
            using (var context = new Context())
            {
                var values = context.DietContents.Include(x => x.AppUser).ToList();
                return values;
            }
        }
    }
}
