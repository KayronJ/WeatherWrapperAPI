using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using WeatherWrapperAPI.Models.Requests;
using WeatherWrapperAPI.Services.Interfaces;

namespace WeatherWrapperAPI.Controllers
{
    [ApiController]
    [Route("api/weather-wrapper")]
    [EnableRateLimiting("fixed")]
    public class WeatherWrapperController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        public WeatherWrapperController(IWeatherService weatherService) 
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        [Route("current")]
        public async Task<IActionResult> GetCurrentWeatherAsync([FromQuery] CurrentWeatherRequest request) 
        {
            var requestResult = await _weatherService.GetCurrentWeatherByCityAsync(request);
            return Ok(requestResult);
        }

        [HttpGet]
        [Route("forecast/daily")]
        public async Task<IActionResult> GetDailyForecastWeatherAsync([FromQuery] ForecastWeatherRequest request)
        {
            var requestResult = await _weatherService.GetDailyForecastWeatherByCityAsync(request);
            return Ok(requestResult);
        }
    }
}
