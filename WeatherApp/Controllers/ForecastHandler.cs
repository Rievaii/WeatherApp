using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.JavaScript;
using WeatherApp.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Net.NetworkInformation;

namespace WeatherApp.Controllers
{
    public class ForecastHandler : Controller
    {

        /// <summary>
        /// Get weather by coords
        /// </summary>
        /// <param name="longitude">Долгота</param>
        /// <param name="latitude">Широта</param>
        public static async Task<ForecastModel> GetWeatherByCoords(double longitude, double latitude)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://api.openweathermap.org")
            };
            string apiKey = "bf67c183f4735841de205d2e3fa7ed34";
            using HttpResponseMessage response = await client.GetAsync(String.Format("data/2.5/weather?lat={0}&lon={1}&APPID={2}&units=metric&lang=ru", latitude, longitude, apiKey));
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadFromJsonAsync<ForecastModel>();

            return jsonResponse ?? throw new Exception("Не удается получить прогноз погоды");
            
        }

        public static async Task<LocationGuessModel> GetLocationByName(string locationName)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://api.openweathermap.org")
            };
            string apiKey = "bf67c183f4735841de205d2e3fa7ed34";
            using HttpResponseMessage response = await client.GetAsync(String.Format("/geo/1.0/direct?q={0}&limit=5&appid={1}", locationName, apiKey));
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadFromJsonAsync<List<LocationGuessModel>>();
            return jsonResponse.First();

        }

    }
}
