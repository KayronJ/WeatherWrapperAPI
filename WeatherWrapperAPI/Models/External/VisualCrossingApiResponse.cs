using System.Text.Json.Serialization;

namespace WeatherWrapperAPI.Models.External
{
    public class VisualCrossingApiResponse
    {
        [JsonPropertyName("resolvedAddress")]
        public required string Location { get; set; }
        [JsonPropertyName("description")]
        public required string Description { get; set; }
        [JsonPropertyName("days")]
        public List<VisualCrossingApiFocastResponse> Forecast { get; set; } = new();
        [JsonPropertyName("currentConditions")]
        public VisualCrossingApiCurrentResponse CurrentConditions { get; set; } = new();

    }

    public class VisualCrossingApiCurrentResponse
    {
        [JsonPropertyName("datetime")]
        public TimeSpan ObservedAt { get; set; }
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }
        [JsonPropertyName("feelslike")]
        public double FeelsLike { get; set; }
        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }
        [JsonPropertyName("conditions")]
        public string Conditions { get; set; } = string.Empty;
    }
    public class VisualCrossingApiFocastResponse
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
