namespace WeatherWrapperAPI.Models.Interfaces
{
    public interface ICacheRepository
    {
        Task<string?> GetAsync(string key);
        Task SetAsync(string key, string value);
    }
}
