using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.ViewComponents
{
    public class _TestimonialPartial:ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public _TestimonialPartial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            using (var context = new Context())
            {
                var result = _testimonialService.TGetByStatus(true);
                return View(result);
            }
           
        }
    }
}
