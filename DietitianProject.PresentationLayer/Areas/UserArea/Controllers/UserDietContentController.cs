using DietitianProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class UserDietContentController : Controller
    {
        private readonly IDietContentService _dietContentService;

        public UserDietContentController(IDietContentService dietContentService)
        {
            _dietContentService = dietContentService;
        }

        public IActionResult Index()
        {
            var dietContents = _dietContentService.TGetByStatus(true);
            return View(dietContents);
        }
        public IActionResult Content(int id)
        {
            var dietContents = _dietContentService.TGetById(id);
            return View(dietContents);
        }
    }
}
