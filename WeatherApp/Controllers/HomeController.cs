using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            return View(model);
        }
    }
}