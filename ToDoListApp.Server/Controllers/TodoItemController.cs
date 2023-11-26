using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Server.DbContext;
using ToDoListApp.Server.Entities;
using ToDoListApp.Server.Migrations;
using ToDoListApp.Server.Models.DTO;
using ToDoListApp.Server.Repositories.Interface;

namespace ToDoListApp.Server.Controllers
{
    // https://localhost:xxxx/api/ToDoItem
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

        //----------------------------------------
        // Http method for view all (to do item)
        // VIEW All
        // GET: https://localhost:7259/api/TodoItem
        [HttpGet]
        public async Task<IActionResult> GetAllToDoItems()
        {
           var toDoItem = await todoItemRepository.GetAllAsync();

           // map domain model to dto 
           var response = new List<TodoItemDto>();

           foreach (var item in toDoItem)
            {
                response.Add(new TodoItemDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    Content = item.Content,
                    IsMarked = item.IsMarked,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                });
            }

           return Ok(response);
        }

        //----------------------------------------
        // Http method for create a new (to do item)
        // CREATE
        // Post: api/TodoItem
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
                IsMarked = toDoItem.IsMarked,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            return Ok(response);
        }

        //----------------------------------------
        // Http method for get a single id
        // Get:  https://localhost:7259/api/TodoItem/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetToDoItemById([FromRoute] Guid id) 
        {
            var existingToDoItem = await todoItemRepository.GetById(id);

            // if is not found 
            if (existingToDoItem == null)
            {
                return NotFound();
            }

            // if is found
            var response = new TodoItemDto
            {
                Id= existingToDoItem.Id,
                Title = existingToDoItem.Title,
                Content = existingToDoItem.Content,
                IsMarked = existingToDoItem.IsMarked,
                CreatedAt= existingToDoItem.CreatedAt,
                UpdatedAt = existingToDoItem.UpdatedAt,

            };

            return Ok(response);
        }

        // UPDATE
        // PUT: https://localhost:7259/api/TodoItem/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditToDoItem([FromRoute] Guid id, UpdateToDoItemRequestDto request)
        {
            // convert dto to domain model
            var toDoItem = new ToDoItem
            {
                Id = id,
                Title = request.Title,
                Content = request.Content,
                IsMarked= request.IsMarked,
            };

            toDoItem =await todoItemRepository.UpdateAsync(toDoItem);

            if (toDoItem == null)
            {
                return NotFound();
            }

            // convert domain to dto
            var rsponse = new TodoItemDto
            {
                Id = toDoItem.Id,
                Title = toDoItem.Title,
                Content = toDoItem.Content,
                IsMarked = toDoItem.IsMarked,
                CreatedAt = toDoItem.CreatedAt,
                UpdatedAt = toDoItem.UpdatedAt,
            };

            return Ok(rsponse);
        }


        // DELETE: https://localhost:7259/api/TodoItem/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteToDoItem([FromRoute] Guid id)
        {
            var toDoItem = await todoItemRepository.DeleteAsync(id);

            if (toDoItem is null) 
            {
                return NotFound();
            }

            // convert domain model to dto
            var response = new TodoItemDto
            {
                Id = toDoItem.Id,
                Title = toDoItem.Title,
                Content = toDoItem.Content,
                IsMarked = toDoItem.IsMarked,
                CreatedAt= toDoItem.CreatedAt,
                UpdatedAt= DateTime.UtcNow,
            };

            return Ok(response);
        }

    }
}
 