using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.EntityLayer.Concrete
{
    public class DietitianInfo
    {
        public int  Id { get; set; }
        public string SchoolInfo { get; set; }
        public string Description { get; set; }
        public int AppUserId { get; set; }
        public AppUser    AppUser { get; set; }
    }
}
