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
        public IActionResult Login(LoginRequest request)
        {
            var LoginResponse = _userRepo.Login(request);
            if (LoginResponse.Users == null || string.IsNullOrEmpty(LoginResponse.Token))
                return BadRequest(new { message = "Неправильный логин или пароль" });
            //return auth form
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(RegistrationRequest request) 
        {
            if (_userRepo.isUnique(request.Login))
            {
                var RegistrationResponse = _userRepo.Registration(request);
                return View();

            }
            //такой логин уже существует
            return View();
            //return registration form
        }
    }
}
