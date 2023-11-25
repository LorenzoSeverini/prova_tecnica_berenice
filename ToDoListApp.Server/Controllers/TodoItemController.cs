using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Server.DbContext;
using ToDoListApp.Server.Entities;
using ToDoListApp.Server.Models.DTO;
using ToDoListApp.Server.Repositories.Interface;

namespace ToDoListApp.Server.Controllers
{
    // https://localhost:xxxx/api/todo
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemController : Controller
    {
        private readonly ITodoItemRepository todoItemRepository;

        //TODO : CRUD METHODS

        public TodoItemController(ITodoItemRepository todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> CreateTodoItem(CreateTodoItemRequestDto request)
        {
            // Convert DTO to Domain Model
            var toDoItem = new ToDoItem
            {
                Title = request.Title,
                Content = request.Content
            };

            await todoItemRepository.CreateAsync(toDoItem);

            // Domain model to DTO 
            var response = new TodoItemDto
            {
                Id = toDoItem.Id,
                Title = toDoItem.Title,
                Content = toDoItem.Content,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            return Ok(response);
        }
    }
}
 