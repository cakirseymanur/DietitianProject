using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class SalesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IDietPlanService _dietPlanService;

        public SalesController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ComplateSale(int id)
        {
           var dietPlan= _dietPlanService.TGetById(id);
            return View(dietPlan);
        }
        //[HttpPost]
        //public async Task<IActionResult> ComplateSale(int id)
        //{
        //    var user = await _userManager.FindByNameAsync(User.Identity.Name);
        //    return View();
        //}
    }
}
