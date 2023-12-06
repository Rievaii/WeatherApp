using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;

namespace WeatherApp.Controllers
{
    public class ForecastHandler : Controller
    {
        //Получение погоды по долготе и широте
        public string GetWeather(double longitude, double latitude)
        {
            //String.Format(@"https://api.weather.yandex.ru/v2/informers?lat={0}&lon={1}", latitude, longitude)
            //request.Headers.Add("X-Yandex-API-Key", "d7652fca-3c44-40b9-80a0-179e577d39c9");

            HttpClient httpClient = new HttpClient();
            //https://jsonplaceholder.typicode.com
            //https://api.weather.yandex.ru
            httpClient.BaseAddress = new Uri(@"https://jsonplaceholder.typicode.com");
            httpClient.DefaultRequestHeaders.Add("X-Yandex-API-Key", "d7652fca-3c44-40b9-80a0-179e577d39c9");
               

            using HttpResponseMessage response =  httpClient.GetAsync("todos/3");
            response.Headers.Add("X-Yandex-API-Key", "d7652fca-3c44-40b9-80a0-179e577d39c9");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");
        }
    }
}
