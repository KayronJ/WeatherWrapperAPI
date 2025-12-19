using WeatherWrapperAPI.Models.Requests;
using WeatherWrapperAPI.Models.Responses;

namespace WeatherWrapperAPI.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<CurrentWeatherResponse> GetCurrentWeatherByCityAsync(CurrentWeatherRequest request);
    }
}
