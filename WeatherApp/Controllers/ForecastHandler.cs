using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WeatherApp.Controllers
{
    public class ForecastHandler : Controller
    {
        //Получение погоды по долготе и широте
        public static async Task<string> GetWeather(double longitude, double latitude)
        {
            HttpClient client = new HttpClient() 
            {
                BaseAddress = new Uri("http://api.openweathermap.org")
            };

            using HttpResponseMessage response = await client.GetAsync(String.Format("data/2.5/weather?lat={0}&lon={1}&APPID=bf67c183f4735841de205d2e3fa7ed34", longitude, latitude));
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;
        }
    }
}
