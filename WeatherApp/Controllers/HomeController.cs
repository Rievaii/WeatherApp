using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var forecast = await ForecastHandler.GetWeather(55.811852, 37.567078);
            ViewBag.Result = forecast;
            return View();
        }

       
    }
}