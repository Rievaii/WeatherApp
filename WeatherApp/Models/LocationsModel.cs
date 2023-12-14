namespace WeatherApp.Models
{
    public class LocationsModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int User_id { get; set; }    
        public double Latitude { get; set; } 
        public double Longitude { get; set; }
    }
}
