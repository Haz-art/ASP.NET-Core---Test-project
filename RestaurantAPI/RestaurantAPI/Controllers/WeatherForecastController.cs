using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet] //...5501/WeatherForecast
        public IEnumerable<WeatherForecast> Get()
        {
            //var result = _service.Get();
            return _service.Get();//result
        }

        //handling of several GET queries:
        // 1)
        [HttpGet]
        [Route("currentDay/{max}")] //5501/WeatherForecast/currentDay
        // 2)
        //[HttpGet("currentDay2")]//5501/WeatherForecast/currentDay

        public IEnumerable<WeatherForecast> Get2([FromQuery]int take, [FromRoute]int max)//[parameter origin]int ... //FromBody/FromQuery(/123)/FromHeader/FromRoute(?take=123)
        {
            //var result = _service.Get();
            return _service.Get();//result
        }

        [HttpPost]

        public ActionResult<string> Hello([FromBody] string name)
        {
            HttpContext.Response.StatusCode = 401;
            return $"hello {name}";
        }
    }
}
