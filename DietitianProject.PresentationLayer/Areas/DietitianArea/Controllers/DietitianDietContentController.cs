using AutoMapper;
using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.DtoLayer.DTOs.DietContentDTOs;
using DietitianProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Areas.DietitianArea.Controllers
{
    [Area("DietitianArea")]
    public class DietitianDietContentController : Controller
    {
        private readonly IDietContentService _dietContentService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public DietitianDietContentController(IDietContentService dietContentService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _dietContentService = dietContentService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var dietContents=  _dietContentService.TGetList().Where(x=>x.AppUserId==user.Id).ToList();
            return View(dietContents);
        }
        [HttpGet]
        public IActionResult CreateDietContent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDietContent(CreateDietContentDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                model.CreatedDate = DateTime.Now;
                model.AppUserId = user.Id;
                var content = _mapper.Map<DietContent>(model);
                content.Status = true;
                if (model.Image != null)
                {
                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(model.Image.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var saveLocation = resource + "/wwwroot/Image/DietContentImage/" + imageName;
                    var stream = new FileStream(saveLocation, FileMode.Create);
                    await model.Image.CopyToAsync(stream);
                    content.ImageUrl = imageName;
                }
                _dietContentService.TInsert(content);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateDietContent(int id)
        {
            var dietContent = _dietContentService.TGetById(id);
            var content = _mapper.Map<UpdateDietContentDto>(dietContent);
            return View(content);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDietContent(UpdateDietContentDto model)
        {
            if (ModelState.IsValid)
            {
                var content = _dietContentService.TGetById(model.Id);
                if (model.Image != null)
                {
                    if (content.ImageUrl != null)
                    {
                        System.IO.File.Delete($"wwwroot/Image/DietContentImage/{content.ImageUrl}");
                    }

                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(model.Image.FileName);
                    var imageName = Guid.NewGuid() + extension;

                    var saveLocation = resource + "/wwwroot/Image/DietContentImage/" + imageName;
                    var stream = new FileStream(saveLocation, FileMode.Create);

                    await model.Image.CopyToAsync(stream);
                    content.ImageUrl = imageName;
                } 
                content.Subject = model.Subject;
                content.Content = model.Content;
                _dietContentService.TUpdate(content);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        #region DietitianDietContent
        public IActionResult DietContentIndex()
        {
            var dietContents = _dietContentService.TGetByStatus(true);
            return View(dietContents);
        }
        public IActionResult Content(int id)
        {
            var dietContents = _dietContentService.TGetById(id);
            return View(dietContents);
        }
        #endregion
    }
}
