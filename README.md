[![Nuget](https://img.shields.io/nuget/v/Mehedi.Hangfire.Extensions)](https://www.nuget.org/packages/Mehedi.Hangfire.Extensions/)
[![Nuget](https://img.shields.io/nuget/dt/Mehedi.Hangfire.Extensions)](https://www.nuget.org/packages/Mehedi.Hangfire.Extensions/)

# Mehedi.Hangfire.Extensions
Useful extension methods to be able to use Hangfire to create background jobs. 

## Give a Star! :star:
If you like this project, learn something or you are using it in your applications, please give it a star. Thanks!

## Installation

Install the package via NuGet first:

```Install-Package Mehedi.Hangfire.Extensions```

Or via the .NET Core command line interface:

```dotnet add package Mehedi.Hangfire.Extensions```

Either commands, from Package Manager Console or .NET Core CLI, will download and install package and all required dependencies.

## Getting Started with ASP.NET Core API

### Step 1
Create ASP.NET Core API project. Then install the following dependencies with the following commands.
```
dotnet add package Hangfire
dotnet add package Mehedi.Hangfire.Extensions
```

### Step 2
To store messages we'll need databases. For an example if we want to store messages (http requests etc.) inside postgres, add the following package.
```
dotnet add package Hangfire.PostgreSql
```

### Step 3
Update `appsettings.json` with postgres connection string.
```
  "ConnectionStrings": {
    "HangfireConnection": "Host=localhost;Port=5432;Database=hangfire;Username=postgres;Password=postgres;"
  },
```

### Step 4
Inside `Program.cs` file write the following code snippets.
```csharp
builder.Services.AddHangfire(config =>
{
    config.UsePostgreSqlStorage(c => c.UseNpgsqlConnection(builder.Configuration.GetConnectionString("HangfireConnection")));
    config.UseMediatR(); // Custom extension built on 
});
```

and

```csharp
app.UseHangfireServer();
app.UseHangfireDashboard();
```

### Step 5
Inside Controller simply enque requests like the following code snippets as an example.
```csharp
    [HttpPost("/sales/orders/{orderId:Guid}")]
    public IActionResult Action([FromRoute] Guid orderId)
    {
        _mediator.Enqueue("Place Order", new PlaceOrder
        {
            OrderId = orderId
        });

        return NoContent();
    }
```

If you face any more complexity, then just follow the example project to getting started.
[Example](https://github.com/rabbicse/mehedi.hangfire.extensions/tree/master/examples/Hangfire.Extensions.Example)

## Dependencies
- net8.0
- Hangfire.Core (>= 1.8.12)
- MediatR (>= 12.2.0)

## References
- [Hangfire](https://www.hangfire.io/)
- [Using Hangfire and MediatR as a Message Dispatcher](https://codeopinion.com/using-hangfire-and-mediatr-as-a-message-dispatcher/)
- [Hangfire Postgres](https://github.com/hangfire-postgres)
- [Integrate MediatR with Hangfire](https://github.com/AliBayatGH/CommandScheduler)
