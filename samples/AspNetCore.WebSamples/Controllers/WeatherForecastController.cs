using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public IActionResult GetByPage(int pageIndex = 1, int pageSize = 20)
        {
        // var result = _dapper.Query<WeatherForecast>("select * from WeatherForecast;");
        // var result = _dapper.QueryFirstOrDefault<WeatherForecast>("select * from WeatherForecast;");
        // var result = _dapper.QueryFirstOrDefault<WeatherForecast>("select * from WeatherForecast where Id = @id;",new { id = 1 });
        // var result = _dapper.QuerySingleOrDefault<WeatherForecast>("select * from WeatherForecast;");
        // var result = _dapper.QueryFirstOrDefault<WeatherForecast>("select * from WeatherForecast where Id = @id;",new { id = 1 });
        // var result = _dapper.QueryPlainPage<WeatherForecast>("select * from WeatherForecast limit @Skip,@Take;", pageIndex, pageSize);
        var result = _dapper.QueryPage<WeatherForecast>("select count(*) from WeatherForecast;", "select * from WeatherForecast limit @Take OFFSET @Skip;", pageIndex, pageSize);
        return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _dapper.Get<WeatherForecast>(id);
            return Ok(result);
        }

        [HttpPost]
        public void Post()
        {
            var rng = new Random();
            _dapper.Insert(new WeatherForecast
            {
                Date = DateTime.Now.AddDays(rng.Next(Summaries.Length)),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpDelete("id")]
        public void Delete(int id)
        {
            _dapper.Delete(new WeatherForecast() { Id = id });
        }
    }
}
