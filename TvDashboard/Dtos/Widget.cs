using Microsoft.AspNetCore.Components;

namespace TvDashboard.Dtos
{
    public abstract class Widget : ComponentBase
    {
        [Parameter]
        public string Class { get; set; }
        public int Position { get; set; }
        public abstract string Key { get; }
    }
}