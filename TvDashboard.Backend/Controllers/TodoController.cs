using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TvDashboard.Backend.Models;
using TvDashboard.Backend.Services;

namespace TvDashboard.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly CrudService<Todo> todoService;

        public TodoController(CrudService<Todo> todoService)
        {
            this.todoService = todoService;
        }

        [HttpGet]
        public async Task<List<Todo>> Get()
        {
            return await todoService.GetAllItems();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Todo> GetById([FromRoute] Guid id)
        {
            return await todoService.GetItem(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task Delete([FromRoute] Guid id)
        {
            await todoService.RemoveItem(id);
        }

        [HttpPost]
        public async Task Save([FromBody] Todo todo)
        {
            await todoService.SaveItem(todo);
        }

        [HttpGet]
        [Route("{id:Guid}/check")]
        public async Task Check([FromRoute] Guid id)
        {
            var task = await todoService.GetItem(id);
            task.IsCompleted = !task.IsCompleted;
            await todoService.SaveItem(task);
        }
    }
}