# Dapper.Extension.AspNetCore.MySql

Dapper extensions of MySql Database for ASP.NET Core

### Installation

For more information, please view our [Getting Started](https://github.com/Run2948/Dapper.Extension.AspNetCore/tree/master/src/Dapper.Extension.AspNetCore) guide.

[https://www.nuget.org/packages/Dapper.Extension.AspNetCore.MySql](https://www.nuget.org/packages/Dapper.Extension.AspNetCore.MySql)

```
PM> Install-Package Dapper.Extension.AspNetCore.MySql
```
### Configure

* Add the `AddDapperForMySql()` call into your `ConfigureServices` method of the `Startup` class.

```csharp
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    //...

    public void ConfigureServices(IServiceCollection services)
    {
        //...

        // services.AddDapperForMySql("server=localhost;uid=root;pwd=123456;database=demo;charset=utf8mb4;");

        services.AddDapperForMySql(options =>
        {
            options.ConnectionString = Configuration.GetConnectionString("MySql");
        });

        //...
    }
}
```

* `appsettings.{env}.json`:

```json
{
  "ConnectionStrings": {
    "MySql": "server=localhost;uid=root;pwd=123456;database=demo;charset=utf8mb4;"
  }
}
```

### Usage

```csharp
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IDapper _dapper;

    public WeatherForecastController(IDapper dapper)
    {
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
```