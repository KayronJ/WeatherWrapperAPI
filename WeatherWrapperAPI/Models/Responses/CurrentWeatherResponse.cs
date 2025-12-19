using System.Text.Json.Serialization;

namespace WeatherWrapperAPI.Models.Responses
{
    public class CurrentWeatherResponse
    {
            [JsonPropertyName("resolvedAddress")]
            public required string Location { get; set; }
            [JsonPropertyName("description")]
            public required string Description { get; set; }
            [JsonPropertyName("datetime")]
            public TimeSpan ObservedAt { get; set; }
            [JsonPropertyName("temp")]
            public double Temperature { get; set; }
            [JsonPropertyName("feelslike")]
            public double FeelsLike { get; set; }
            [JsonPropertyName("humidity")]
            public double Humidity { get; set; }
            [JsonPropertyName("conditions")]
            public string Conditions { get; set; }
    }
}
