using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TvDashboard.Backend.Services
{
    public interface ICrudService<T> where T : ICrudItem, new ()
    {
        Task SaveItem(T item);
        Task RemoveItem(Guid id);
        Task<T> GetItem(Guid id);
        Task<List<T>> GetAllItems();
    }

    public interface ICrudItem
    {
        public Guid Id { get; set; }
    }
}