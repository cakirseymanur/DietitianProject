using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.DtoLayer.DTOs.SaleDTOs
{
    public class GetSalesInfoDto
    {
        public string DietPlanName { get; set; }
        public string ImageUrl { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserNameSurname { get; set; }
        public DateTime SaleDate { get; set; }
        public string SalePrice { get; set; }
    }
}
