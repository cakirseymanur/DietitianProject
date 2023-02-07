using DietitianProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.ViewComponents
{
    public class _TotalEarningPartial : ViewComponent
    {
        private readonly ISalesService _salesService;

        public _TotalEarningPartial(ISalesService salesService)
        {
            _salesService = salesService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _salesService.TGetList();
            return View(result);
        }
    }
}
