using DietitianProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Areas.DietitianArea.Controllers
{
    [Area("DietitianArea")]
    public class DietitianHomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DietitianHomeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.User = await _userManager.FindByNameAsync(User.Identity.Name);
            return View();
        }
    }
}
