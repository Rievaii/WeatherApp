using WeatherApp.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WeatherApp.Controllers.Security
{
    public class SecurityController : Controller
    {
        private readonly WeatherDataContext ctx;

        public SecurityController(WeatherDataContext _ctx)
        {
            ctx = _ctx;
        }

        public IActionResult AuthorizationForm()
        {
            return View();
        }

        public IActionResult HandleForm(string Login, string Password)
        {
            //var form = context.Request.Form;
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
                //redirect to error 
                return View("AuthorizationForm");

            UsersModel? CurrentUser = ctx.Users.FirstOrDefault(p => p.Login == Login && p.Password == Password);
            //if (CurrentUser is null) return Results.Unauthorized();

            //add cookies
            return View("~/Views/Home/Index.cshtml", CurrentUser);
        }
    }
}
