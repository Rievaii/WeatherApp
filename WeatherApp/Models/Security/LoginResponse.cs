namespace WeatherApp.Models.Security
{
    public class LoginResponse
    {
        public required UsersModel Users { get; set; }
        public required string Token { get; set; }   
    }
}
