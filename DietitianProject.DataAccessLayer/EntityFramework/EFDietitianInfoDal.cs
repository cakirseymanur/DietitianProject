using DietitianProject.DataAccessLayer.Abstract;
using DietitianProject.DataAccessLayer.Concrete;
using DietitianProject.DataAccessLayer.Repository;
using DietitianProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.DataAccessLayer.EntityFramework
{
    public class EFDietitianInfoDal : GenericRepository<DietitianInfo>, IDietitianInfoDal
    {
        public EFDietitianInfoDal(Context context) : base(context)
        {
        }
    }
}
