using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.EntityLayer.Concrete
{
    public class Testimonial
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
