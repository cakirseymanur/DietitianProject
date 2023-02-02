using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Controllers
{
    public class DietitianInfoController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
