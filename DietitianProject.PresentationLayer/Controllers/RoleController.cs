using AutoMapper;
using DietitianProject.DtoLayer.DTOs.AppRoleDTOs;
using DietitianProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        #region Role İşlemleri

        public IActionResult Index()
        {
            ViewBag.Roles = _roleManager.Roles.ToList();
            return View();
        }
        //[HttpGet]
        //public IActionResult AddRole()
        //{
        //    return View();
        //}
        [HttpPost]
        public async Task<IActionResult> AddRole(CreateRoleDto p)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = _mapper.Map<AppRole>(p);
                var result = await _roleManager.CreateAsync(appRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //[HttpGet]
        //public IActionResult UpdateRole(int id)
        //{
        //    var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
        //    return View(role);
        //}
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto updateRole)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == updateRole.Id);
            role.Name = updateRole.Name;
            var result = await _roleManager.UpdateAsync(role);
            
                var values = JsonConvert.SerializeObject(result.Succeeded);
                return Json(values);
        }
        #endregion
        #region Rol Atama İşlemleri
        [HttpGet]
        public IActionResult AssignRole()
        {
            ViewBag.Roles = _roleManager.Roles.ToList();
            ViewBag.Users = _userManager.Users.ToList();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetUsersInRole(string roleName)
        {
            var usersRoles = await _userManager.GetUsersInRoleAsync(roleName);
            var values = JsonConvert.SerializeObject(usersRoles);
            return Json(values);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(string roleName, string userName)
        {
            var user =await _userManager.FindByNameAsync(userName);
            var role = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, role);
            await _userManager.AddToRoleAsync(user, roleName);
            return Json(true);
        }
        #endregion
    }
}
