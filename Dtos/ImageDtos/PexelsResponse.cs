using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TvDashboard.Dtos.ImageDtos
{
    public class PexelsResponse
    {
        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
        public int Page { get; set; }
        public List<PexelsImage> Photos { get; set; }
    }
}