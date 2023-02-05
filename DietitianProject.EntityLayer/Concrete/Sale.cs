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

        public int AppUserId { get; set; }

        public int DietPlanId { get; set; }

        public decimal Price { get; set; }
        public DateTime SalesDate { get; set; }
    }
}
