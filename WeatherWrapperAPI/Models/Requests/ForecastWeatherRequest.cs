using System.ComponentModel.DataAnnotations;
using WeatherWrapperAPI.Models.Enums;

namespace WeatherWrapperAPI.Models.Requests
{
    public class ForecastWeatherRequest
    {
        [Required]
        public string City { get; set; } = string.Empty;
        [Required] 
        public ETemperatureUnit TemperatureUnit { get; set; }
        [Required]
        public int FutherDays { get; set; }
    }
}
