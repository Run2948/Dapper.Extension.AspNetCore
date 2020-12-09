using System;
using Dapper.Contrib.Extensions;

namespace AspNetCore.WebSamples
{
    [Table("WeatherForecast")]
    public class WeatherForecast
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        [Write(false)]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
