using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherApp.Controllers
{
    [Route("ForecastApiController")]
    [ApiController]
    public class ForecastApiController : ControllerBase
    {
        // GET ForecastApiController/Moscow
        [HttpGet("{prompt}")]
        public async Task<IEnumerable<LocationGuessModel>> GetLocationByName(string prompt)
        {
            return await ForecastHandler.GetLocationsByName(prompt);  
        }

        // GET ForecastApiController/lat/lon
        [HttpGet("{lat}/{lon}")]
        public async Task<ForecastModel> GetWeatherByCoords(double lat, double lon)
        {
            return await ForecastHandler.GetWeatherByCoords(lon, lat);
        }

        // POST <ForecastApiController>/ForecastModel 
        [HttpPost]
        public void Post([FromBody] ForecastModel currestForecast)
        {
        }
    }
}
