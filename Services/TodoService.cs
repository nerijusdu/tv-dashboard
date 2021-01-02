using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TvDashboard.Dtos;

namespace TvDashboard.Services
{
    public interface ITodoService
    {
        Task AddTodo(TodoDto todo);
        Task DeleteTodo(Guid id);
        Task CheckTodo(Guid id);
        Task<List<TodoDto>> GetAllTasks();
    }
    
    public class TodoService : ITodoService
    {
        public Task AddTodo(TodoDto todo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTodo(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task CheckTodo(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoDto>> GetAllTasks()
        {
            return Task.FromResult(new List<TodoDto>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "My first task",
                    Description = "ass",
                    CreatedOn = DateTime.Now,
                    IsCompleted = false
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "My second task",
                    Description = "ass2",
                    CreatedOn = DateTime.Now.AddDays(-1),
                    IsCompleted = true
                }
            });
        }
    }
}