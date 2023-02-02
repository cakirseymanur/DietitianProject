using AutoMapper;
using DietitianProject.DtoLayer.DTOs.AppUserDTOs;
using DietitianProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ProfileDto profileDto = _mapper.Map<ProfileDto>(user);
            var roles = await _userManager.GetRolesAsync(user);
            ViewBag.Image = user.ImageURL;
            ViewBag.Role = roles.FirstOrDefault();
            return View(profileDto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(ProfileDto profileDto)
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
                user.Name = profileDto.Name;
                user.Surname = profileDto.Surname;
                user.Email = profileDto.Email;
                user.UserName = profileDto.UserName;
                var updateUser = await _userManager.UpdateAsync(user);
                if (updateUser.Succeeded)
                {
                    return RedirectToAction("Index");
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
