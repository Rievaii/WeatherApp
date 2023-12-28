using WeatherApp.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeatherApp.Models.Security.Abstract;
using WeatherApp.Models.Security;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WeatherApp.Controllers.Security
{
    public class UsersController : Controller, IUsers
    {
        private readonly WeatherDataContext ctx;
        private string secretKey;

        public UsersController(WeatherDataContext _ctx, IConfiguration configuration)
        {
            ctx = _ctx;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret")!;
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
            //add cookies
            if (1==1)
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

        public bool isUnique(string username)
        {
            if (ctx.Users.Any(x => x.Login == username))
            {
                return true;
            }
            else { return false; }
        }

        public LoginResponse Login(LoginRequest loginRequest)
        {
            if (ctx.Users.Any(p => p.Login.ToLower() == loginRequest.Login.ToLower() && p.Password == loginRequest.Password))
            {
                UsersModel? CurrentUser = ctx.Users.FirstOrDefault(p => p.Login.ToLower() == loginRequest.Login.ToLower() && p.Password == loginRequest.Password);
                
                var tokenHandler = new JwtSecurityTokenHandler();

                //Вытаскиваем наш ключ в виде массива байт 
                var key = Encoding.ASCII.GetBytes(secretKey);
                
                //Описание токена: клеймы в зашифрованном виде, срок и зашифрованная подпись на основе key
                var tokenDescriptior = new SecurityTokenDescriptor()
                {
                    //Требования к данным для идентификаци
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, CurrentUser!.Id.ToString()),

                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    //Удостоверяющие подписи
                    SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                //Создаем токен по указанным статам
                var token = tokenHandler.CreateToken(tokenDescriptior);

                LoginResponse loginResponse = new LoginResponse()
                {
                    Token = tokenHandler.WriteToken(token),
                    Users = CurrentUser
                };
                return loginResponse;
            }else 
            { 
                return new LoginResponse() { Token="", Users = null };   
            }
        }

        public UsersModel Registration(RegistrationRequest registrationRequest)
        {
            UsersModel newUser = new UsersModel() { Login = registrationRequest.Login, Password = registrationRequest.Password };
            ctx.Users.Add(newUser);
            ctx.SaveChanges();
            newUser.Password = "";
            return newUser;
        }
    }
}
