using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TvDashboard.Dtos.Weather
{
    public class WeatherResponseDto
    {
        [JsonPropertyName("name")]
        public string CityName { get; set; }

        public List<WeatherDto> Weather { get; set; }
        public WeatherMainDto Main { get; set; }
        public WindDto Wind { get; set; }
        public CloudsDto Clouds { get; set; }
    }
}