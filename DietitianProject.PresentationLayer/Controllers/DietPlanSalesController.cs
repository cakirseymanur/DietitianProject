using DietitianProject.BusinessLayer.Abstract;
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

        public DietPlanSalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        public IActionResult Index()
        {
            var sales = _salesService.TGetList();
            return View(sales);
        }
    }
}
