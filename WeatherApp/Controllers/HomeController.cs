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
            var forecast = await ForecastHandler.GetWeatherByCoords(37.3263, 55.82633);
            ViewBag.Result = forecast;
            
            ViewBag.FirstUser = ctx.Users.Where(x => x.Id == 1).FirstOrDefault().Login;
            //ctx.Users.Add(new UsersModel() {
            //    Login  = "TestUser",
            //    Password = "123"
            //});
            //ctx.SaveChanges();
                return View();
        }
    }
}