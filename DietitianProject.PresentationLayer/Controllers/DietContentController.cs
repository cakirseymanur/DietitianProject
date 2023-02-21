using AutoMapper;
using DietitianProject.BusinessLayer.CQRS.Queries.DietContentQueries;
using DietitianProject.EntityLayer.Concrete;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Controllers
{
    public class DietContentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public DietContentController(IMediator mediator, IMapper mapper, UserManager<AppUser> userManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllDietContentQuery());
            return View(values);
        }
    }
}
