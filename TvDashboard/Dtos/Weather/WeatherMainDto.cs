using System.Text.Json.Serialization;

namespace TvDashboard.Dtos.Weather
{
    public class WeatherMainDto
    {
        public decimal Temp { get; set; }
        [JsonPropertyName("feels_like")]
        public decimal FeelsLike { get; set; }
        public decimal Humidity { get; set; }
    }
}