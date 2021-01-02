using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TvDashboard.Dtos.Weather;

namespace TvDashboard.Services
{
    public interface IWeatherService
    {
        Task<WeatherResponseDto> GetCurrentWeather();
    }
    
    public class WeatherSerice : IWeatherService
    {
        private readonly HttpClient httpClient;
        private readonly string uri;
        private readonly string apiKey;
        private string city = "Vilnius";
        
        public WeatherSerice(IConfiguration configuration)
        {
            uri = configuration["weatherApiUrl"];
            apiKey = configuration["weatherApiKey"];
            httpClient = new ();
        }

        public async Task<WeatherResponseDto> GetCurrentWeather()
        {
            var res = await httpClient.GetFromJsonAsync<WeatherResponseDto>(
                $"{uri}?q={city}&units=metric&appId={apiKey}");

            return res;
        }
    }
}