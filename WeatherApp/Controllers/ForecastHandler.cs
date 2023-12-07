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
        public string GetWeather(double longitude, double latitude)
        {
            //String.Format(@"https://api.weather.yandex.ru/v2/informers?lat={0}&lon={1}", latitude, longitude)
            //request.Headers.Add("X-Yandex-API-Key", "d7652fca-3c44-40b9-80a0-179e577d39c9");

            //https://jsonplaceholder.typicode.com
            //https://api.weather.yandex.ru


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://api.weather.yandex.ru/v2/informers/");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Headers.Add("X-Yandex-API-Key", "d7652fca-3c44-40b9-80a0-179e577d39c9");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }

        }
    }
}
