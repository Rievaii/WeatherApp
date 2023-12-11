namespace WeatherApp.Models
{
    public class SessionsModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Expires { get; set; }
    }
}
