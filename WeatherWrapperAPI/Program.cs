using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using WeatherWrapperAPI.Configuration;
using WeatherWrapperAPI.Infrastructure.Cache;
using WeatherWrapperAPI.Infrastructure.ExternalClients;
using WeatherWrapperAPI.Models.Interfaces;
using WeatherWrapperAPI.Services;
using WeatherWrapperAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().
    AddJsonOptions(options => 
    { 
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.AddFixedWindowLimiter("fixed", options =>
    {
        options.PermitLimit = 10;
        options.Window = TimeSpan.FromSeconds(10);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 0;
    });
});

builder.Services.AddOptions<VisualCrossingOptions>()
    .BindConfiguration("VisualCrossingWeather");

var sec = builder.Configuration.GetSection("RedisCache");

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = sec.GetValue<string>("RedisConnectionString");
    options.InstanceName = sec.GetValue<string>("WeatherRedisInstanceName");
});

builder.Services.AddHttpClient();
builder.Services.AddScoped<IExternalWeatherClient, VisualCrossingClient>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<ICacheRepository, RedisCacheRepository>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRateLimiter();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
