using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var forecast = await ForecastHandler.GetWeatherByCoords(37.3263, 55.82633);
            ViewBag.Result = forecast;
            return View();
        }
    }
}