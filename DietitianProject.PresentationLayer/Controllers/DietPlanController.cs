using AutoMapper;
using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.DtoLayer.DTOs.DietPlanDTOs;
using DietitianProject.EntityLayer.Concrete;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Controllers
{
    public class DietPlanController : Controller
    {
        private readonly IDietPlanService _dietPlanService;
        private readonly IMapper _mapper;

        public DietPlanController(IDietPlanService dietPlanService, IMapper mapper)
        {
            _dietPlanService = dietPlanService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var dietplans = _dietPlanService.TGetList();
            return View(dietplans);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDietPlanDto dietPlan)
        {
            if (ModelState.IsValid)
            {
                dietPlan.CreatedDate = DateTime.Now;
                var diet = _mapper.Map<DietPlan>(dietPlan);
                if (dietPlan.Image != null)
                {
                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(dietPlan.Image.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var saveLocation = resource + "/wwwroot/Image/DietPlanImage/" + imageName;
                    var stream = new FileStream(saveLocation, FileMode.Create);
                    await dietPlan.Image.CopyToAsync(stream);
                    diet.ImageUrl = imageName;
                }
                if (dietPlan.Pdf!=null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + $"{dietPlan.Name}.pdf");
                    var stream = new FileStream(path, FileMode.Create);

                    Document document = new Document(PageSize.A4);
                    PdfWriter.GetInstance(document, stream);
                    document.Open();
                    Paragraph paragraph = new Paragraph(dietPlan.Pdf);
                    document.Add(paragraph);
                    document.Close();
                    diet.PdfURL = $"{dietPlan.Name}.pdf";
                }
                _dietPlanService.TInsert(diet);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var dietPlan = _dietPlanService.TGetById(id);
            var plan = _mapper.Map<UpdateDietPlanDto>(dietPlan);
            return View(plan);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateDietPlanDto dietPlan)
        {
            if (ModelState.IsValid)
            {
                var diet = _dietPlanService.TGetById(dietPlan.Id);
                 //diet = _mapper.Map<DietPlan>(dietPlan);
                if (dietPlan.Image != null)
                {
                    if (diet.ImageUrl != null)
                    {
                        System.IO.File.Delete($"wwwroot/Image/DietPlanImage/{diet.ImageUrl}");
                    }

                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(dietPlan.Image.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    
                    var saveLocation = resource + "/wwwroot/Image/DietPlanImage/" + imageName; 
                    var stream = new FileStream(saveLocation, FileMode.Create);

                    await dietPlan.Image.CopyToAsync(stream);
                    diet.ImageUrl = imageName;
                }
                if (dietPlan.Pdf != null)
                { 
                    if (diet.PdfURL != null)
                    {
                        System.IO.File.Delete("wwwroot/PdfReports/" + $"{dietPlan.Name}.pdf");
                    }
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + $"{dietPlan.Name}.pdf");
                    var stream = new FileStream(path, FileMode.Create);
                    
                    Document document = new Document(PageSize.A4);
                    PdfWriter.GetInstance(document, stream);
                    document.Open();
                    Paragraph paragraph = new Paragraph(dietPlan.Pdf);
                    document.Add(paragraph);
                    document.Close();
                    diet.PdfURL = $"{dietPlan.Name}.pdf";
                }
                diet.Name = dietPlan.Name;
                diet.Price = dietPlan.Price;
                diet.Description = dietPlan.Description;
                _dietPlanService.TUpdate(diet);
                return RedirectToAction("Index");
            }
            return View(dietPlan);
        }
        public IActionResult Delete(int id)
        { 
          var values = _dietPlanService.TGetById(id);
          _dietPlanService.TDelete(values);
          return RedirectToAction("Index"); 
        }
        public IActionResult InstallPdf(int id)
        {
            var dietPlan = _dietPlanService.TGetById(id);
            return File($"/PdfReports/{dietPlan.Name}.pdf", "application/pdf", $"{dietPlan.Name}.pdf");
        }
        public IActionResult ChangeDietPlanStatusToFalse(int id)
        {
            _dietPlanService.TChangeDietPlanStatusToFalse(id);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeDietPlanStatusToTrue(int id)
        {
            _dietPlanService.TChangeDietPlanStatusToTrue(id);
            return RedirectToAction("Index");
        }
    }
}
