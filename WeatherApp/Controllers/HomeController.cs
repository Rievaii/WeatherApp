using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherDataContext ctx;

        public HomeController(WeatherDataContext _ctx)
        {
            ctx = _ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        // ForecastApiController/lat/lon
        public IActionResult Forecast(double lat, double lon)
        {
            var forecast = Task.Run(() => ForecastHandler.GetWeatherByCoords(lon, lat)).Result;
            ViewBag.Country = "RU";
            return View(forecast);
        }
    }
}