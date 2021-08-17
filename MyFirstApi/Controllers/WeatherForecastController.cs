using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApi.Controllers
{
    [ApiController] //says that it will be responding with json or xml
    [Route("WeatherForecast")] 
    //how should this controller be exposed to the internet - at what url?
    //it says - take the name of this controller class by going to my url/weatherForecast.
    //**This is how you get to the class
    public class WeatherForecastController : ControllerBase //don't mess with the ControllerBase - it is very useful and FREE!
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        [HttpGet("numbers")] //**this is how you get to the method
        public List<int> GetNumbers()
        {
            return new List<int> { 1, 3, 5, 7, 9 };
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            //taking numbers 1 thru 5 and converting weather forecast info
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
