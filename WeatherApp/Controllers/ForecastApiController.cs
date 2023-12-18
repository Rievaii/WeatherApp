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
    }
}
