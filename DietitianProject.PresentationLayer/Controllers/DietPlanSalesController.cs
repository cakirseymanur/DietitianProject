using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Controllers
{
    public class DietPlanSalesController : Controller
    {
        private readonly ISalesService _salesService;
        private readonly IDietPlanService _dietPlanService;

        public DietPlanSalesController(ISalesService salesService, IDietPlanService dietPlanService)
        {
            _salesService = salesService;
            _dietPlanService = dietPlanService;
        }

        public IActionResult Index()
        {
            var sales = _salesService.TGetAllSaleInfo();
            return View(sales);
        }

        public List<SalesChartViewModel> DietPlanSalesCount()
        {
            var sales = _salesService.TGetAllSaleInfo();
            var dietPlan = _dietPlanService.TGetList();
            List<SalesChartViewModel> models = new List<SalesChartViewModel>();
            foreach (var item in dietPlan)
            {
                models.Add(new SalesChartViewModel
                {
                    Name = item.Name,
                    Count = sales.Where(x => x.DietPlanId == item.Id).Count()
                });
            }

            return models;
        }
    }
}
