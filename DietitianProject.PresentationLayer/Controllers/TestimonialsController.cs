using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System; 
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Controllers
{
    public class TestimonialsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITestimonialService _testimonialService;

        public TestimonialsController(UserManager<AppUser> userManager , ITestimonialService testimonialService)
        {
            _userManager = userManager; 
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var testimonials = _testimonialService.TGetListWithUser();
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
            return RedirectToAction("Index", "UserHome", new { area = "UserArea" });
            
        }

        public IActionResult ChangeTestimonialStatusToFalse(int id)
        {
            _testimonialService.TChangeTestimonialStatusToFalse(id);
            return RedirectToAction("Index");
        }
         public IActionResult ChangeTestimonialStatusToTrue(int id)
         { 
            _testimonialService.TChangeTestimonialStatusToTrue(id); 
            return RedirectToAction("Index");
         }

        public IActionResult Delete(int id)
        { 
                var values = _testimonialService.TGetById(id);
                _testimonialService.TDelete(values);
                return RedirectToAction("Index");  
        }
    }
}
