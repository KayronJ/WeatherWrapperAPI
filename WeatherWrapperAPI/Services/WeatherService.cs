using System.Text.Json;
using WeatherWrapperAPI.Models.Interfaces;
using WeatherWrapperAPI.Models.Requests;
using WeatherWrapperAPI.Models.Responses;
using WeatherWrapperAPI.Services.Interfaces;

namespace WeatherWrapperAPI.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IExternalWeatherClient _externalWeatherClient;
        private readonly ICacheRepository _cache;

        public WeatherService(IExternalWeatherClient externalWeatherClient, ICacheRepository cache)
        {
            _externalWeatherClient = externalWeatherClient;
            _cache = cache;
        }

        public async Task<CurrentWeatherResponse> GetCurrentWeatherByCityAsync(CurrentWeatherRequest request)
        {

            var cache = await _cache.GetAsync($"{request.City}-{request.TemperatureUnit}");

            if(!string.IsNullOrEmpty(cache))
                return JsonSerializer.Deserialize<CurrentWeatherResponse>(cache)!;

            var response = await _externalWeatherClient.GetCurrentWeatherByCityAsync(request.City, request.TemperatureUnit);

            var returnDto = new CurrentWeatherResponse
            {
                Location = response.Location,
                Description = response.Description,
                ObservedAt = response.CurrentConditions.ObservedAt,
                Temperature = response.CurrentConditions.Temperature,
                FeelsLike = response.CurrentConditions.FeelsLike,
                Humidity = response.CurrentConditions.Humidity,
                Conditions = response.CurrentConditions.Conditions
            };

            await _cache.SetAsync($"{request.City}-{request.TemperatureUnit}", JsonSerializer.Serialize(returnDto));

            return returnDto;
        }

        public async Task<ForecastWeatherResponse> GetDailyForecastWeatherByCityAsync(ForecastWeatherRequest request)
        {
            var cache = await _cache.GetAsync($"{request.City}-{request.TemperatureUnit}-{request.FutherDays}");

            if (!string.IsNullOrEmpty(cache))
                return JsonSerializer.Deserialize<ForecastWeatherResponse>(cache)!;

            var response = await _externalWeatherClient.GetDailyForecastWeatherByCityAsync(request.City, request.TemperatureUnit, request.FutherDays);

            var returnDto = new ForecastWeatherResponse
            {
                CurrentWeather = new CurrentWeatherResponse
                {
                    Location = response.Location,
                    Description = response.Description,
                    ObservedAt = response.CurrentConditions.ObservedAt,
                    Temperature = response.CurrentConditions.Temperature,
                    FeelsLike = response.CurrentConditions.FeelsLike,
                    Humidity = response.CurrentConditions.Humidity,
                    Conditions = response.CurrentConditions.Conditions
                },
                ForecastDays = response.Forecast.Select(x => new ForecastWeatherDaysResponse
                {
                    Day = x.Day,
                    MaxTemperature = x.MaxTemperature,
                    MinTemperature = x.MinTemperature,
                    Humidity = response.CurrentConditions.Humidity,
                    Conditions = response.CurrentConditions.Conditions
                }).ToList()
            };

            await _cache.SetAsync($"{request.City}-{request.TemperatureUnit}-{request.FutherDays}", JsonSerializer.Serialize(returnDto));

            return returnDto;
        }
    }
}
