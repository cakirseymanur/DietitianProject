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
    public class _DietitianInfoesPartial : ViewComponent
    {
        public IViewComponentResult  Invoke()
        {
            using (var context = new Context())
            {
                var userList = context.UserRoles.Where(x => x.RoleId == 2).Select(s=>s.UserId).FirstOrDefault();
                var result = context.Users.Where(x => x.Id == userList).ToList();
               return View(result);
            }
        }
    }
}
