using DietitianProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.ViewComponents
{
    public class _AdminNavbarPartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _AdminNavbarPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(result);
        }
    }
}
