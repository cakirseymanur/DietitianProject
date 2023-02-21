using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.EntityLayer.Concrete
{
    public class DietContent
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public string ImageUrl { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
