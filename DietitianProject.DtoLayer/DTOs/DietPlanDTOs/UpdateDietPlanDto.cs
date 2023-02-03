using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.DtoLayer.DTOs.DietPlanDTOs
{
    public class UpdateDietPlanDto
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } 
        public string Pdf{ get; set; }
        public IFormFile Image{ get; set; }
    }
}
