using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.DtoLayer.DTOs.DietContentDTOs
{
    public class CreateDietContentDto
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public IFormFile Image { get; set; }
        public int AppUserId { get; set; }
    }
}
