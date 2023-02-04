using DietitianProject.DataAccessLayer.Abstract;
using DietitianProject.DataAccessLayer.Repository;
using DietitianProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.DataAccessLayer.EntityFramework
{
    public class EFSalesDal:GenericRepository<Sale>,ISalesDal
    {
    }
}
