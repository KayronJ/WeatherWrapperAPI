using System.Text.Json.Serialization;

namespace WeatherWrapperAPI.Models.Responses
{
    public class ForecastWeatherDaysResponse
    {
        [JsonPropertyName("datetime")]
        public DateTime Day { get; set; }
        [JsonPropertyName("tempmax")]
        public double MaxTemperature { get; set; }
        [JsonPropertyName("tempmin")]
        public double MinTemperature { get; set; }
        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }
        [JsonPropertyName("conditions")]
        public string Conditions { get; set; } = string.Empty;
    }
}
