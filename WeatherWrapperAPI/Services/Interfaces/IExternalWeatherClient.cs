using WeatherWrapperAPI.Models.Enums;
using WeatherWrapperAPI.Models.External;

namespace WeatherWrapperAPI.Services.Interfaces
{
    public interface IExternalWeatherClient
    {
        Task<VisualCrossingApiResponse> GetCurrentWeatherByCityAsync(string city, ETemperatureUnit temperatureUnit);
        Task<VisualCrossingApiResponse> GetDailyForecastWeatherByCityAsync(string city, ETemperatureUnit temperatureUnit, int nextDays);
    }
}
