using AutoMapper;
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
    public class TestimonialsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialsController(UserManager<AppUser> userManager, IMapper mapper, ITestimonialService testimonialService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var testimonials = _testimonialService.TGetList();
            return View(testimonials);
        }

        public async Task<IActionResult> Create(string description)
        {
            if (description!=null)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                Testimonial testimonial = new Testimonial()
                {
                    Description = description,
                    AppUserId = user.Id,
                    Status = false,
                    CreatedDate = DateTime.Now 
                };
                _testimonialService.TInsert(testimonial);
            }
            return RedirectToAction("Index","Home", new { area = "UserArea" });
        }


    }
}
