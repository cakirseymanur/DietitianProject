using DietitianProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.ViewComponents
{
    public class _TotalDietPlanPartial : ViewComponent
    {
        private readonly IDietPlanService _dietPlanService;

        public _TotalDietPlanPartial(IDietPlanService dietPlanService)
        {
            _dietPlanService = dietPlanService;
        }
        public IViewComponentResult Invoke()
        {
            var result = _dietPlanService.TGetByStatus(true);
            return View(result);
        }
    }
}
