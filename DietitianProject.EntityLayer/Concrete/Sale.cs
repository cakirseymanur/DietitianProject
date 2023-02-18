using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.EntityLayer.Concrete
{
    public class Sale
    {
        public int Id { get; set; }

        public virtual int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public virtual int? DietPlanId { get; set; }
        public DietPlan DietPlan { get; set; }

        public decimal Price { get; set; }
        public DateTime SalesDate { get; set; }
    }
}
