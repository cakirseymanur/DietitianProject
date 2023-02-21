using AutoMapper;
using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.BusinessLayer.CQRS.Queries.DietContentQueries;
using DietitianProject.DtoLayer.DTOs.DietContentDTOs;
using DietitianProject.EntityLayer.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Controllers
{
    public class DietContentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDietContentService _dietContentService;

        public DietContentController(IMediator mediator, IMapper mapper, UserManager<AppUser> userManager, IDietContentService dietContentService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userManager = userManager;
            _dietContentService = dietContentService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllDietContentQuery());
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDietContentDto model)
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
        public IActionResult Update(int id)
        {
            var dietContent = _dietContentService.TGetById(id);
            var content = _mapper.Map<UpdateDietContentDto>(dietContent);
            return View(content);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateDietContentDto model)
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
        public IActionResult Delete(int id)
        {
            var values = _dietContentService.TGetById(id);
            _dietContentService.TDelete(values);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeDietContentStatusToFalse(int id)
        {
            _dietContentService.TChangeDietContentStatusToFalse(id);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeDietContentStatusToTrue(int id)
        {
            _dietContentService.TChangeDietContentStatusToTrue(id);
            return RedirectToAction("Index");
        }
    }
}
