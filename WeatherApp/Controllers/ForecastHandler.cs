using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.JavaScript;
using WeatherApp.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WeatherApp.Controllers
{
    public class ForecastHandler : Controller
    {
        //Получение погоды по долготе и широте
        public static async Task<ForecastModel> GetWeather(double longitude, double latitude)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://api.openweathermap.org")
            };

            using HttpResponseMessage response = await client.GetAsync(String.Format("data/2.5/weather?lat={0}&lon={1}&APPID=bf67c183f4735841de205d2e3fa7ed34", longitude, latitude));
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadFromJsonAsync<ForecastModel>();

            return jsonResponse ?? throw new Exception("Не удается получить прогноз погоды");
            
        }
    }
}
