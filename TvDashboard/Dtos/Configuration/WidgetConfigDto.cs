using System.Collections.Generic;

namespace TvDashboard.Dtos.Configuration
{
    public class WidgetConfigDto
    {
        public string Key { get; set; }
        public int Position { get; set; }
        public Dictionary<string, string> Options { get; set; }
    }
}