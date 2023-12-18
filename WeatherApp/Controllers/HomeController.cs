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
            var model = new ForecastModel();
            return View(model);
        }

        // ForecastApiController/lat/lon
        public IActionResult Forecast(double lat, double lon)
        {
            var forecast = ForecastHandler.GetWeatherByCoords(lon, lat);
            ViewBag.Country = "RU";
            return View("Index", forecast);
        }
    }
}