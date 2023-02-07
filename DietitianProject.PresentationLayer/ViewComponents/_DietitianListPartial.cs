using DietitianProject.DataAccessLayer.Concrete;
using DietitianProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.ViewComponents
{
    public class _DietitianListPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _DietitianListPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _userManager.GetUsersInRoleAsync("Diyetisyen");
            return View(result);
        }
    }
}
