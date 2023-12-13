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

        public async Task<IActionResult> Index()
        {
            //var forecast = await ForecastHandler.GetWeatherByCoords(37.3263, 55.82633);
            var location = await ForecastHandler.GetLocationByName("Moscow");
            //ViewBag.Result = forecast;
            ViewBag.Location = location;
            ViewBag.FirstUser = ctx.Users.Where(x => x.Id == 1).FirstOrDefault().Login;
                return View();
        }
    }
}