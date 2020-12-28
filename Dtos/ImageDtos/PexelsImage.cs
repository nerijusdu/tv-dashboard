using TvDashboard.Services;

namespace TvDashboard.Dtos.ImageDtos
{
    public class PexelsImage
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
        public string Photographer { get; set; }
        public PexelsImageSource Src { get; set; }
    }
}