using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult AboutPartial()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
