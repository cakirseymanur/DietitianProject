using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.DataAccessLayer.Concrete;
using DietitianProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.ViewComponents
{
    public class _SalesChartPartial : ViewComponent
    {
        private readonly ISalesService _salesService;

        public _SalesChartPartial(ISalesService salesService)
        {
            _salesService = salesService;
        }
        public IViewComponentResult Invoke()
        {
            var sales = _salesService.TGetList();
            using (var context = new Context())
            {
                var salesInfo = (from s in context.Sales
                             join u in context.Users on s.AppUserId equals u.Id
                             join d in context.DietPlans on s.DietPlanId equals d.Id
                             select new SalesInfoViewModel
                             {
                                 UserName = u.UserName,
                                 UserNameSurname = u.Name+" "+u.Surname,
                                 DietPlanName = d.Name,
                                 DietPlanImage = d.ImageUrl,
                                 Price=s.Price,
                                 SaleDate=s.SalesDate
                             }).ToList();

                return View(salesInfo);
            }
        }
    }
}