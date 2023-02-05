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
    public class MyDietPlansController : Controller
    {
        private readonly ISalesService _salesService;
        private readonly UserManager<AppUser> _userManager;

        public MyDietPlansController(ISalesService salesService, UserManager<AppUser> userManager)
        {
            _salesService = salesService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var dietPlan=_salesService.TGetMyDietPlans(user.Id);
            return View(dietPlan);
        }
    }
}
