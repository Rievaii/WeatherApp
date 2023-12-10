namespace WeatherApp.Models
{
    public class UsersModel
    {
        public int Id { get; set; } 
        public required string Login { get; set; }
        public required string Password { get; set; }
    }
}
