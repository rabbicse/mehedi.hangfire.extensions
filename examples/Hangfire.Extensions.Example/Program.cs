using Hangfire;
using Hangfire.PostgreSql;
using Mehedi.Hangfire.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddControllers();

builder.Services.AddHangfire(config =>
{
    config.UsePostgreSqlStorage(c => c.UseNpgsqlConnection(builder.Configuration.GetConnectionString("HangfireConnection")));
    config.UseMediatR(); // Custom extension built on 
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add hangfire support
app.UseHangfireServer();
app.UseHangfireDashboard();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
