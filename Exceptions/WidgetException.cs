using System;

namespace TvDashboard.Exceptions
{
    public class WidgetException : Exception
    {
        public WidgetException()
        {
        }

        public WidgetException(string message) : base(message)
        {
        }

        public WidgetException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}