using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TvDashboard.Services;

namespace TvDashboard
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(_ => new HttpClient
            {
                BaseAddress = new (builder.HostEnvironment.BaseAddress)
            });

            builder.Services.AddSingleton<IImageService, ImageService>();
            builder.Services.AddSingleton<IWidgetService, WidgetService>();
            builder.Services.AddSingleton<IWeatherService, WeatherSerice>();

            await builder.Build().RunAsync();
        }
    }
}