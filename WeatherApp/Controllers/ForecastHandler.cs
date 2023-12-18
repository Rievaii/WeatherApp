﻿using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.JavaScript;
using WeatherApp.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Net.NetworkInformation;
using System;

namespace WeatherApp.Controllers
{
    public class ForecastHandler : Controller
    {

        /// <summary>
        /// Get weather by coords
        /// </summary>
        /// <param name="longitude">Долгота</param>
        /// <param name="latitude">Широта</param>
        /// <returns>ForecastModel by lon & lat</returns>

        public static ForecastModel GetWeatherByCoords(double longitude, double latitude)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://api.openweathermap.org")
            };
            string apiKey = "bf67c183f4735841de205d2e3fa7ed34";
            using HttpResponseMessage response =  client.GetAsync(String.Format("data/2.5/weather?lat={0}&lon={1}&APPID={2}&units=metric&lang=ru", latitude, longitude, apiKey)).Result;
            response.EnsureSuccessStatusCode();
            var jsonResponse = response.Content.ReadFromJsonAsync<ForecastModel>().Result;

            return jsonResponse ?? throw new Exception("Не удается получить прогноз погоды");
            
        }

        /// <summary>
        /// Call api to retrieve assigned by prompt locations 
        /// </summary>
        /// <param name="prompt">Prompt to API search</param>
        /// <returns>A collection of found 5 locations</returns>
        public static IEnumerable<LocationGuessModel> GetLocationsByName(string prompt)
        {
            using (StreamReader r = new StreamReader(Path.Combine(Environment.CurrentDirectory, "wwwroot/Resources/city.list.json")))
            {
                //check if we have requested city locally
                IEnumerable<LocationGuessModel> foundLocations;
                string json = r.ReadToEnd();
                if (!string.IsNullOrEmpty(json))
                {
                    //limit 5
                    foundLocations = JsonConvert.DeserializeObject<List<LocationGuessModel>>(json).Where(x => x.Name.ToLower() == prompt.ToLower());
                    var test = 1;
                    if (foundLocations.Any())
                        return foundLocations;
                }
            }
            throw new Exception("Такой локации не было найдено");
            return null;
            //HttpClient client = new HttpClient()
            //{
            //    BaseAddress = new Uri("http://api.openweathermap.org")
            //};
            //string apiKey = "bf67c183f4735841de205d2e3fa7ed34";
            //using HttpResponseMessage response = client.GetAsync(String.Format("/geo/1.0/direct?q={0}&limit=5&appid={1}", prompt, apiKey)).Result;
            //response.EnsureSuccessStatusCode();
            //var jsonResponse = response.Content.ReadFromJsonAsync<IEnumerable<LocationGuessModel>>().Result;
            ////if timeout generate random value for testing
            //return jsonResponse ?? throw new Exception("Такой локации не было найдено");
        }

    }
}
