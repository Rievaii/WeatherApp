using System.ComponentModel;

namespace WeatherApp.Models
{
    public class ForecastModel
    {
        public string? Name { get; set; }
        public List<Weather?> weather { get; set; }
        public Wind? wind { get; set; }
        public Main? main { get; set; }
    }
    public class Weather
    {
        public string? Main { get; set; }
        public string? Description { get; set; }
    }

    public class Wind
    {
        public double? Speed { get; set; }
        public double? Deg { get; set; }
        public double? Gust { get; set; }
    }

    public class Main
    {
        public double? Temp { get; set; }
        public double? Feels_like { get; set; }
        public double? Temp_min { get; set; }
        public double? Temp_max { get; set; }
        public double? Pressure { get; set; }
        public double? Humidity { get; set; }

    }

}

