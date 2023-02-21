using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.DtoLayer.DTOs.DietContentDTOs
{
    public class UpdateDietContentDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public IFormFile Image { get; set; }
    }
}
