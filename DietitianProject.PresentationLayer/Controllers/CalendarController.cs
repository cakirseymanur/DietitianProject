using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Controllers
{
    public class CalendarController : Controller
    {
        private readonly IEventService _eventService;

        public CalendarController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
        { 
            return View();
        }
        [HttpGet]
        public IActionResult GetAllEvents()
        {
            var values = _eventService.TGetList();
            return new JsonResult(values);
        }
        [HttpPost]
        public IActionResult AddEvents(Event e)
        { 
           _eventService.TInsert(e);
            return new JsonResult(true);
        }
        public IActionResult UpdateEvents(Event e)
        {
            _eventService.TUpdate(e);
            return new JsonResult(true);
        }
        public IActionResult DeleteEvents(int id)
        {
            if (id > 0)
            {
                var values = _eventService.TGetById(id);
                _eventService.TDelete(values);
            }
            else
            {
                return new JsonResult(false);
            }
            return new JsonResult(true);
        }
    }
}
