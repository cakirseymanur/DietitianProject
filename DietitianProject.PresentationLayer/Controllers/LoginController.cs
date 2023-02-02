using DietitianProject.BusinessLayer.ValidationRules.AppUserValidator;
using DietitianProject.DtoLayer.DTOs.AppUserDTOs;
using DietitianProject.EntityLayer.Concrete;
using FluentValidation;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SignInDto appUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(appUser.UserName, appUser.Password, false, true);
                if (result.Succeeded)
                {
                    var user = _userManager.Users.FirstOrDefault(x => x.UserName == appUser.UserName);
                    var role = await _userManager.GetRolesAsync(user);
                    if (role.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (role.Contains("Dietitian"))
                    {
                        return RedirectToAction("Index", "Dietitian");
                    }
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("UserName", "Geçersiz kullanıcı adı.");
                }
            }
            return View();
        }
        
    }
}
