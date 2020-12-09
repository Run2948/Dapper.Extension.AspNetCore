# Dapper.Extension.AspNetCore

Dapper extensions for ASP.NET Core.

## Packages & Status
Packages | NuGet
---------|------
Dapper.Extension.AspNetCore|[![NuGet package](https://buildstats.info/nuget/Dapper.Extension.AspNetCore)](https://www.nuget.org/packages/Dapper.Extension.AspNetCore)
Dapper.Extension.AspNetCore.MySql|[![NuGet package](https://buildstats.info/nuget/Dapper.Extension.AspNetCore.MySql)](https://www.nuget.org/packages/Dapper.Extension.AspNetCore.MySql)



### Dapper.Extension.AspNetCore.MySql

Dapper extensions of MySql Database for ASP.NET Core.

**Installation**

For more information, please view our [Getting Started](https://github.com/Run2948/Dapper.Extension.AspNetCore/tree/master/src/Dapper.Extension.AspNetCore.MySql) guide.

[https://www.nuget.org/packages/Dapper.Extension.AspNetCore.MySql](https://www.nuget.org/packages/Dapper.Extension.AspNetCore.MySql)

```
PM> Install-Package Dapper.Extension.AspNetCore.MySql
```

**Configure**

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

**Usage**

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
```