using DietitianProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
			return View();
		}
		public async Task<IActionResult> GetCalorie(string foodName)
        {
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://edamam-food-and-grocery-database.p.rapidapi.com/parser?ingr="+foodName),
				Headers =
	    {
	    	{ "X-RapidAPI-Key", "8353feee66mshf5988d224e46636p1a9300jsncc4fab7ab9cd" },
	    	{ "X-RapidAPI-Host", "edamam-food-and-grocery-database.p.rapidapi.com" },
	    },
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var calorie = JsonConvert.DeserializeObject<CalorieViewModel.Rootobject>(body);
				return Json(JsonConvert.SerializeObject(calorie.parsed));
			}
		}

		//public async Task<IActionResult> Translate(string text)
		//{
		//	var client = new HttpClient();
  //          var request = new HttpRequestMessage
  //          {
  //          	Method = HttpMethod.Post,
  //          	RequestUri = new Uri("https://rapid-translate-multi-traduction.p.rapidapi.com/t"),
  //          	Headers =
  //          	{
  //          		{ "X-RapidAPI-Key", "8353feee66mshf5988d224e46636p1a9300jsncc4fab7ab9cd" },
  //          		{ "X-RapidAPI-Host", "rapid-translate-multi-traduction.p.rapidapi.com" },
  //          	},
  //          	Content = new StringContent("{\r\'from\': \'tr\',\r\'to\': \'en\',\r\'e\': \'\',\r\'q\': [\r\'text\'\r]\r}" )
  //          	{
  //          		Headers =
  //          		{
  //          			ContentType = new MediaTypeHeaderValue("application/json")
  //          		}
  //          	}
  //          };
  //          using (var response = await client.SendAsync(request))
  //          {
  //          	response.EnsureSuccessStatusCode();
  //          	var body = await response.Content.ReadAsStringAsync();
  //          	Console.WriteLine(body);
  //          }
		//	return View();
		//}

	}
}
