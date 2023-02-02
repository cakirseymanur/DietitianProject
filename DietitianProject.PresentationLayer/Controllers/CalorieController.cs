using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Controllers
{
    public class CalorieController : Controller
    {
        public async Task<IActionResult> Index()
        {
			//var client = new HttpClient();
			//var request = new HttpRequestMessage
			//{
			//	Method = HttpMethod.Get,
			//	RequestUri = new Uri("https://edamam-food-and-grocery-database.p.rapidapi.com/parser?ingr=apple"),
			//	Headers =
	  //          {
		 //      { "X-RapidAPI-Key", "8353feee66mshf5988d224e46636p1a9300jsncc4fab7ab9cd" },
		 //      { "X-RapidAPI-Host", "edamam-food-and-grocery-database.p.rapidapi.com" },
	  //          },	       
			//};
			//using (var response = await client.SendAsync(request))
			//{
			//	response.EnsureSuccessStatusCode();
			//	var body = await response.Content.ReadAsStringAsync();
			//	Console.WriteLine(body);
			//}
			return View();
        }
    }
}
