using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using TvDashboard.Components;
using TvDashboard.Dtos;
using TvDashboard.Dtos.Configuration;
using TvDashboard.Exceptions;

namespace TvDashboard.Services
{
    public interface IWidgetService
    {
        Dictionary<int, string> WidgetClasses { get; }
        Dictionary<int, Widget> GetWidgets();
    }
    
    public class WidgetService : IWidgetService
    {
        private readonly List<WidgetConfigDto> WidgetConfigs;
        
        private static readonly List<Type> WidgetTypes = new()
        {
            typeof(Clock),
            typeof(Weather),
        };

        public WidgetService(IConfiguration configuration)
        {
            WidgetConfigs = configuration.GetSection("widgets").Get<List<WidgetConfigDto>>();
        }

        public Dictionary<int, string> WidgetClasses { get; } = new()
        {
            {1, "flex justify-start items-start"},
            {2, "flex justify-center items-start"},
            {3, "flex justify-center items-start"},
            {4, "flex justify-end items-start"},
            {5, "flex justify-start items-center"},
            {6, "flex justify-center items-center"},
            {7, "flex justify-center items-center"},
            {8, "flex justify-end items-center"},
            {9, "flex justify-start items-end"},
            {10, "flex justify-center items-end"},
            {11, "flex justify-center items-end"},
            {12, "flex justify-end items-end"}
        };

        public Dictionary<int, Widget> GetWidgets()
        {
            return WidgetTypes.Select(CreateWidget).ToDictionary(x => x.Position, x => x);
        }

        private Widget CreateWidget(Type type)
        {
            if (!type.IsSubclassOf(typeof(Widget)))
            {
                throw new WidgetException($"Widgets must inherit {nameof(Widget)} class");
            }
                
            var widget = Activator.CreateInstance(type) as Widget;
            if (widget == null)
            {
                throw new WidgetException($"Failed to initialize widget of type: {type}");
            }
            
            var widgetConfig = WidgetConfigs.FirstOrDefault(x => x.Key == widget.Key);
            if (widgetConfig == null)
            {
                throw new WidgetException($"Could not find configuration for widget with key: {widget.Key}");
            }

            widget.Position = widgetConfig.Position;

            return widget;
        }
    }
}