using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models.Security;
using WeatherApp.Models.Security.Abstract;

namespace WeatherApp.Controllers.Security
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUsers _userRepo;
        public AuthController(IUsers userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost("login")]
        public IActionResult Login([FromForm] LoginRequest request)
        {
            var LoginResponse = _userRepo.Login(request);
            if (LoginResponse.Users == null || string.IsNullOrEmpty(LoginResponse.Token))
            {
                @ViewBag.LoginError = "Неправильный логин или пароль";
                return View("~/Views/Security/AuthorizationForm.cshtml");
            }
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost("register")]
        public IActionResult Register(RegistrationRequest request) 
        {
            if (_userRepo.isUnique(request.Login))
            {
                var RegistrationResponse = _userRepo.Registration(request);
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                ViewBag.RegistrationError = "Такой логин уже существует";
                return View("~/Views/Security/RegistrationForm.cshtml");
            }
        }
    }
}
