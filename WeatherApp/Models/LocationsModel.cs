namespace WeatherApp.Models
{
    public class LocationsModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int User_id { get; set; }    
        public float Latitude { get; set; } 
        public float Longitude { get; set; }
    }
}
