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
        public IViewComponentResult Invoke()
        {  
           return View(); 
        }
    }
}