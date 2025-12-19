using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using WeatherWrapperAPI.Configuration;
using WeatherWrapperAPI.Models.Enums;
using WeatherWrapperAPI.Models.External;
using WeatherWrapperAPI.Services.Interfaces;

namespace WeatherWrapperAPI.Infrastructure.ExternalClients
{
    public class VisualCrossingClient : IExternalWeatherClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly VisualCrossingOptions _visualCrossingSettings;

        public VisualCrossingClient(IHttpClientFactory httpClientFactory,
            IOptions<VisualCrossingOptions> options)
        {
            _httpClientFactory = httpClientFactory;
            _visualCrossingSettings = options.Value;
        }
        public async Task<VisualCrossingApiResponse> GetCurrentWeatherByCityAsync(string city, ETemperatureUnit temperatureUnit)
        {
            var client = _httpClientFactory.CreateClient();

            var queryParams = new Dictionary<string, string?>
            {
                ["unitGroup"] = temperatureUnit.ToString().ToLower(),
                ["key"] = _visualCrossingSettings.ApiKey
            };

            var url = QueryHelpers.AddQueryString($"{ _visualCrossingSettings.BaseUrl}{city}", queryParams);

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var weatherResponse = System.Text.Json.JsonSerializer.Deserialize<VisualCrossingApiResponse>(content);

            return weatherResponse;
        }
    }
}
