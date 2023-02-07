using Braintree;
using DietitianProject.BusinessLayer.Abstract;
using DietitianProject.DataAccessLayer.Concrete;
using DietitianProject.EntityLayer.Concrete;
using DietitianProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class SalesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IDietPlanService _dietPlanService;
        private readonly ISalesService _salesService;
        private readonly IBraintreeService _braintreeService;
        public SalesController(UserManager<AppUser> userManager, IBraintreeService braintreeService, IDietPlanService dietPlanService, ISalesService salesService)
        {
            _userManager = userManager;
            _braintreeService = braintreeService;
            _dietPlanService = dietPlanService;
            _salesService = salesService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ComplateSale(int id)
        {
            var user =await _userManager.FindByNameAsync(User.Identity.Name);
            DietPlan dietPlan = _dietPlanService.TGetById(id);
            Sale sale = new Sale();
            sale.DietPlanId = id;
            sale.AppUserId = user.Id;
            sale.SalesDate = DateTime.Now;
            sale.Price = dietPlan.Price;
           
            _salesService.TInsert(sale);

            return RedirectToAction("Index", "UserHome", new { area = "UserArea"});
        }
        //[HttpPost]
        //public async Task<IActionResult> ComplateSale(int id)
        //{
        //    var user = await _userManager.FindByNameAsync(User.Identity.Name);
        //    return View();
        //}
        public IActionResult Purchase(int id)
        {
            var dietPlan = _dietPlanService.TGetById(id);
            var gateway = _braintreeService.GetGateway();
            var clientToken = gateway.ClientToken.Generate();  //Genarate a token
            ViewBag.ClientToken = clientToken;

            var data = new DietPlanViewModel
            {
                Id = dietPlan.Id,
                Description = dietPlan.Description,
                Name = dietPlan.Name,
                ImageUrl = dietPlan.ImageUrl,
                Price = dietPlan.Price,
                Nonce = ""
            };

            return View(data);
        }
        [HttpPost]
        public IActionResult Purchase(DietPlanViewModel model)
        {
            var gateway = _braintreeService.GetGateway();
            var request = new TransactionRequest
            {
                Amount = Convert.ToDecimal(model.Price),
                PaymentMethodNonce = model.Nonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                return RedirectToAction("ComplateSale", "Sales", new { area = "UserArea",id= model.Id });
            }
            else
            {
                return View("Failure");
            }
        }
        public IActionResult Failure()
        {
            return View();
        }
    }
}
