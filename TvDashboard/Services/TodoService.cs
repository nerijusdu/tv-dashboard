using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TvDashboard.Dtos;

namespace TvDashboard.Services
{
    public interface ITodoService : ISubscribable<List<TodoDto>>
    {
        Task AddTodo(TodoDto todo);
        Task DeleteTodo(Guid id);
        Task CheckTodo(Guid id);
        Task<List<TodoDto>> GetAllTasks();
    }
    
    public class TodoService : ITodoService
    {
        private readonly HttpClient client;
        private readonly int refreshInterval;
        private const string TodoWidgetKey = "todos";

        public TodoService(IConfiguration configuration, IWidgetService widgetService)
        {
            client = new()
            {
                BaseAddress = new($"{configuration["apiUrl"]}/todo/")
            };

            var refreshInMinutes = int.Parse(widgetService.WidgetConfigs
                .First(x => x.Key == TodoWidgetKey)
                .Options["refreshInMinutes"]);
            refreshInterval = refreshInMinutes * 60 * 1000;
        }

        public async Task AddTodo(TodoDto todo)
        {
            await client.PostAsJsonAsync("", todo);
        }

        public async Task DeleteTodo(Guid id)
        {
            await client.DeleteAsync($"{id}");
        }

        public async Task CheckTodo(Guid id)
        {
            await client.GetAsync($"{id}/check");
        }

        public async Task<List<TodoDto>> GetAllTasks()
        {
            var todos = await client.GetFromJsonAsync<List<TodoDto>>("");
            return (todos ?? new ())
                .OrderBy(x => x.IsCompleted)
                .ThenByDescending(x => x.CreatedOn)
                .ToList();
        }

        public void Subscribe(Action<List<TodoDto>> setTodos)
        {   
            var timer = new Timer(async _ =>
            {
                setTodos(await GetAllTasks());
            }, null, 0, refreshInterval);
        }
    }
}