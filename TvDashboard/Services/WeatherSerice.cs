using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TvDashboard.Dtos.Weather;

namespace TvDashboard.Services
{
    public interface IWeatherService : ISubscribable<WeatherResponseDto>
    {
        Task<WeatherResponseDto> GetCurrentWeather();
    }
    
    public class WeatherSerice : IWeatherService
    {
        private readonly HttpClient httpClient;
        private readonly string uri;
        private readonly string apiKey;
        private string city = "Vilnius";
        private readonly int refreshInterval;
        private const string WeatherWidgetKey = "todos";
        
        public WeatherSerice(IConfiguration configuration, IWidgetService widgetService)
        {
            uri = configuration["weatherApiUrl"];
            apiKey = configuration["weatherApiKey"];
            httpClient = new ();

            var refreshInMinutes = int.Parse(widgetService.WidgetConfigs
                .First(x => x.Key == WeatherWidgetKey)
                .Options["refreshInMinutes"]);
            refreshInterval = refreshInMinutes * 60 * 1000;
        }

        public async Task<WeatherResponseDto> GetCurrentWeather()
        {
            var res = await httpClient.GetFromJsonAsync<WeatherResponseDto>(
                $"{uri}?q={city}&units=metric&appId={apiKey}");

            return res;
        }

        public void Subscribe(Action<WeatherResponseDto> setWeather)
        {
            var timer = new Timer(async _ =>
            {
                setWeather(await GetCurrentWeather());
            }, null, 0, refreshInterval);
        }
    }
}