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
            var model = ForecastHandler.GetWeatherByCoords(lon, lat);
            ViewBag.Country = "Russia";
            ViewBag.State = "UD";
            //validate model if error return error view
            return View(model);
        }
    }
}