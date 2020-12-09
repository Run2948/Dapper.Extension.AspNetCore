# Dapper.Extension.AspNetCore.MySql

Dapper extensions of MySql Database for ASP.NET Core

### Install Package

[https://www.nuget.org/packages/Dapper.Extension.AspNetCore.MySql](https://www.nuget.org/packages/Dapper.Extension.AspNetCore.MySql)

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

* Configure the `ConnectionStrings` section in your `appsettings.{env}.json`.

```json
{
  "ConnectionStrings": {
    "MySql": "server=localhost;uid=root;pwd=123456;database=demo;charset=utf8mb4;"
  },
  ...
}
```