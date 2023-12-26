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

        /// <summary>
        /// Login Form
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        /// <returns>Index view with user model if authorized</returns>
        public IActionResult HandleForm(string Login, string Password)
        {
            //var form = context.Request.Form;
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
            {
                ViewBag.LoginError = "Введите логин или пароль";
                return View("AuthorizationForm");
            }

            if (ctx.Users.Any(p => p.Login == Login && p.Password == Password))
            {
                UsersModel? CurrentUser = ctx.Users.FirstOrDefault(p => p.Login == Login && p.Password == Password);
                return View("~/Views/Home/Index.cshtml", CurrentUser);

            }
            else
            {
                ViewBag.LoginError = "Неправильный логин/пароль";
                return View("AuthorizationForm");
            }
        }
    }
}
