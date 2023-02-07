using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Models
{
    public class SalesInfoViewModel
    {
        public string UserName { get; set; }
        public string UserNameSurname { get; set; }
        public string DietPlanName { get; set; }
        public string DietPlanImage { get; set; }
        public decimal Price { get; set; }
        public DateTime SaleDate { get; set; }

    }
}
