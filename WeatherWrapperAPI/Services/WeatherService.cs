using WeatherWrapperAPI.Models.Requests;
using WeatherWrapperAPI.Models.Responses;
using WeatherWrapperAPI.Services.Interfaces;

namespace WeatherWrapperAPI.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IExternalWeatherClient _externalWeatherClient;
        public WeatherService(IExternalWeatherClient externalWeatherClient)
        {
            _externalWeatherClient = externalWeatherClient;
        }

        public async Task<CurrentWeatherResponse> GetCurrentWeatherByCityAsync(CurrentWeatherRequest request)
        {
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

            return returnDto;
        }
    }
}
