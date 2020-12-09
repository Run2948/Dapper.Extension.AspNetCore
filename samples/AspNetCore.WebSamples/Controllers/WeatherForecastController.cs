using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Extension.AspNetCore;

namespace AspNetCore.WebSamples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IDapper _dapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDapper dapper)
        {
            _logger = logger;
            _dapper = dapper;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var list = _dapper.GetAll<WeatherForecast>().ToList();

            if (!list.Any())
            {
                var rng = new Random();
                list = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }).ToList();
                _dapper.Insert(list);

                list = _dapper.GetAll<WeatherForecast>().ToList();
            }

            return list;
        }
    }
}
