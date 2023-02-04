using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Models
{
    public class CalorieViewModel
    {

        public class Rootobject
        {
            public string text { get; set; }
            public Parsed[] parsed { get; set; }
        }

        public class Parsed
        {
            public Food food { get; set; }
        }

        public class Food
        {
            public string foodId { get; set; }
            public string uri { get; set; }
            public string label { get; set; }
            public Nutrients nutrients { get; set; }
            public string category { get; set; }
            public string categoryLabel { get; set; }
            public string image { get; set; }
        }

        public class Nutrients
        {
            public decimal ENERC_KCAL { get; set; }
            public float PROCNT { get; set; }
            public float FAT { get; set; }
            public float CHOCDF { get; set; }
            public float FIBTG { get; set; }
        }
    }
}
