using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace TvDashboard.Backend.Services
{
    public class CrudService<T> : ICrudService<T> where T : ICrudItem, new ()
    {
        private readonly SQLiteAsyncConnection db;

        public CrudService(DbService dbService)
        {
            db = dbService.GetAsyncConnection;
        }
        
        public async Task SaveItem(T item)
        {
            await db.InsertOrReplaceAsync(item);
        }

        public async Task RemoveItem(Guid id)
        {
            await db.DeleteAsync<T>(id);
        }

        public async Task<T> GetItem(Guid id)
        {
            return await db.GetAsync<T>(x => x.Id == id);
        }

        public async Task<List<T>> GetAllItems()
        {
            return await db.Table<T>().ToListAsync();
        }
    }
}