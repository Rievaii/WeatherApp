using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    [Authorize]
    public class ForecastController : Controller
    {
        private readonly WeatherDataContext ctx;

        public ForecastController(WeatherDataContext _ctx)
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
            //find location by lat lon 
            ViewBag.Country = "Russia";
            ViewBag.State = "UD";
            //validate model if error return error view
            return View(model);
        }
    }
}