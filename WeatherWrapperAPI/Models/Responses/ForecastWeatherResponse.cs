using System.Text.Json.Serialization;

namespace WeatherWrapperAPI.Models.Responses
{
    public class ForecastWeatherResponse
    {
        [JsonPropertyName("currentConditions")]
        public CurrentWeatherResponse? CurrentWeather { get; set; }
        [JsonPropertyName("days")]
        public List<ForecastWeatherDaysResponse>? ForecastDays { get; set; }
    }
}
