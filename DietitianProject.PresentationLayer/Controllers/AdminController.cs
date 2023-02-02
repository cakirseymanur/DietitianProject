using AutoMapper;
using DietitianProject.DtoLayer.DTOs.AppUserDTOs;
using DietitianProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager; 
        private readonly IMapper _mapper;

        public AdminController(UserManager<AppUser> userManager, IMapper mapper )
        {
            _userManager = userManager;
            _mapper = mapper; 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ProfileDto profileDto = _mapper.Map<ProfileDto>(user);
            var roles = await _userManager.GetRolesAsync(user);
            ViewBag.Image = user.ImageURL;
            ViewBag.Role = roles.FirstOrDefault();
            return View(profileDto);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(ProfileDto profileDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                
                if (profileDto.Password != null)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, profileDto.Password);
                }
                if (profileDto.Image != null)
                {
                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(profileDto.Image.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var saveLocation = resource + "/wwwroot/Image/UserImage/" + imageName;
                    var stream = new FileStream(saveLocation, FileMode.Create);
                    await profileDto.Image.CopyToAsync(stream);
                    user.ImageURL = imageName;
                }
                var updateUser = await _userManager.UpdateAsync(user);  
                if (updateUser.Succeeded)
                {
                    return RedirectToAction("Profile", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Bilgileriniz güncellenemedi");
                }
            }
            return View();
        }
       
    }
}
