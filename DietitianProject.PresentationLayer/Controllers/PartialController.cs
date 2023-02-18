using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Controllers
{
    public class PartialController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITestimonialService _testimonialService;

        public PartialController(UserManager<AppUser> userManager, ITestimonialService testimonialService)
        {
            _userManager = userManager;
            _testimonialService = testimonialService;
        }

        public IActionResult WhyUsPartial()
        {
            return View();
        }
        public IActionResult FooterPartial()
        {
            return View();
        }
        public IActionResult ContactPartial()
        {
            return View();
        }
        public IActionResult ClientPartial()
        {
            return View();
        }
    }
}
