# Dapper.Extension.AspNetCore

Dapper extensions for ASP.NET Core.

## Packages & Status
Packages | NuGet
---------|------
Dapper.Extension.AspNetCore|[![NuGet package](https://buildstats.info/nuget/Dapper.Extension.AspNetCore)](https://www.nuget.org/packages/Dapper.Extension.AspNetCore)
Dapper.Extension.AspNetCore.MySql|[![NuGet package](https://buildstats.info/nuget/Dapper.Extension.AspNetCore.MySql)](https://www.nuget.org/packages/Dapper.Extension.AspNetCore.MySql)

## Features

For these extensions to work, the entity in question _MUST_ have a
key property. Dapper will automatically use a property named "`id`" 
(case-insensitive) as the key property, if one is present.

```csharp
public class WeatherForecast
{
    public int Id { get; set; } // Works by convention

    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public string Summary { get; set; }
}
```

If the entity doesn't follow this convention, decorate 
a specific property with a `[Key]` or `[ExplicitKey]` attribute.

```csharp
[Table("WeatherForecast")]
public class WeatherForecast
{
    [Key]
    public int ForecastId { get; set; }

    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    [Write(false)]
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string Summary { get; set; }
}
```

All Attributes
-------

* `[Table("Tablename")]` - use another table name instead of the (by default pluralized) name of the class

* `[Key]` - this property represents a database-generated identity/key
  
* `[ExplicitKey]` - this property represents an explicit identity/key which is 
  *not* automatically generated by the database 

* `[Write(true/false)]` -  this property is (not) writable

* `[Computed]` - this property is computed and should not be part of updates


`Query` methods
-------

Get `one specific entity`

```csharp
var result = _dapper.QueryFirstOrDefault<WeatherForecast>("select * from WeatherForecast;");

var result = _dapper.QuerySingleOrDefault<WeatherForecast>("select * from WeatherForecast;");

var result = _dapper.QueryFirstOrDefault<WeatherForecast>("select * from WeatherForecast where Id = @id;",new { id = 1 });

var result = _dapper.QueryFirstOrDefault<WeatherForecast>("select * from WeatherForecast where Id = @id;",new { id = 1 });
```

or a list of `all entities` in the table

```csharp
var result = _dapper.Query<WeatherForecast>("select * from WeatherForecast;");
```

or a list of `all entities by page` in the table.

```csharp
var result = _dapper.QueryPlainPage<WeatherForecast>("select * from WeatherForecast limit @Skip,@Take;", pageIndex, pageSize);

var result = _dapper.QueryPage<WeatherForecast>("select count(*) from WeatherForecast;", "select * from WeatherForecast limit @Take OFFSET @Skip;", pageIndex, pageSize);
```

`Get` methods
-------

Get one specific entity based on id

```csharp
var forecast = _dapper.Get<WeatherForecast>(1);
```

or a list of all entities in the table.

```csharp
var forecasts = _dapper.GetAll<WeatherForecast>();
```

`Insert` methods
-------

Insert one entity

```csharp
_dapper.Insert(new WeatherForecast { Name = "Volvo" });
```

or a list of entities.

```csharp
_dapper.Insert(forecasts);
```


`Update` methods
-------
Update one specific entity

```csharp
_dapper.Update(new WeatherForecast() { Id = 1, Name = "Saab" });
```

or update a list of entities.

```csharp
_dapper.Update(forecasts);
```

`Delete` methods
-------
Delete an entity by the specified `[Key]` property

```csharp
_dapper.Delete(new WeatherForecast() { Id = 1 });
```

a list of entities

```csharp
_dapper.Delete(forecasts);
```

or _ALL_ entities in the table.

```csharp
_dapper.DeleteAll<WeatherForecast>();
```



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