using DietitianProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Models
{
    public class DietPlanViewModel:DietPlan
    {
        public string Nonce { get; set; }
    }
}
