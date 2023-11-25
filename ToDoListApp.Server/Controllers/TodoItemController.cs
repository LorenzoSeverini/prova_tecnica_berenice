using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Server.DbContext;
using ToDoListApp.Server.Entities;
using ToDoListApp.Server.Models.DTO;

namespace ToDoListApp.Server.Controllers
{
    // https://localhost:xxxx/api/todo
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemController : Controller
    {
        //TODO : CRUD METHODS

        // Constructor
        private readonly ToDoListAppDbContext dbContext;

        public TodoItemController(ToDoListAppDbContext dbContext)
        {
            this.dbContext = dbContext;
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

            // Injecteted services ( save the changes on database using SaveChangesAsync )
            await dbContext.ToDoItems.AddAsync(toDoItem);
            await dbContext.SaveChangesAsync();

            // Domain model to DTO 
            var response = new TodoItemDto
            {
                Id = toDoItem.Id,
                Title = toDoItem.Title,
                Content = toDoItem.Content,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            return Ok(response);
        }

    }
}
 