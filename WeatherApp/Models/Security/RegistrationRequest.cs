using Microsoft.AspNetCore.Razor.Language;

namespace WeatherApp.Models.Security
{
    public class RegistrationRequest
    {
        public required string Login { get; set; }
        public required string Password { get; set; } 
    }
}
