using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherApp.Controllers
{
    [Route("ForecastApiController")]
    [ApiController]
    [Authorize]
    public class ForecastApiController : ControllerBase
    {
        // GET ForecastApiController/Moscow
        [HttpGet("{prompt}")]
        public  IEnumerable<LocationGuessModel> GetLocationByName(string prompt)
        {
            return  ForecastHandler.GetLocationsByName(prompt);  
        }
    }
}
