using System;

namespace TvDashboard.Services
{
    public interface ISubscribable<T>
    {
        void Subscribe(Action<T> setValue);
    }
}