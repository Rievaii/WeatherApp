using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using WeatherApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherApp.Controllers
{
    [Route("ForecastApiController")]
    [ApiController]
    public class ForecastApiController : ControllerBase
    {
        // GET: api/<ForecastApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET ForecastApiController/Moscow
        [HttpGet("{prompt}")]
        public async Task<LocationGuessModel> GetLocationByName(string prompt)
        {
            return await ForecastHandler.GetLocationByName(prompt);  
        }

        // POST api/<ForecastApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ForecastApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ForecastApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
