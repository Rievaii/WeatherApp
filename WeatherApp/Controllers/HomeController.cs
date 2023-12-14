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

        public  IActionResult Index()
        {
            //get users first saved model from db 
            var model = new ForecastModel() { Name = "test"};
            //get from location guesser join by lon lat from json list
            ViewBag.State = "Alaska";
            ViewBag.Country = "US";
            return View(model);
        }
    }
}