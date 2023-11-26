using ToDoListApp.Server.Entities;

namespace ToDoListApp.Server.Repositories.Interface
{
    public interface ITodoItemRepository
    {
        // Create
        Task<ToDoItem> CreateAsync(ToDoItem toDoItem);

        // Show all
        Task<IEnumerable<ToDoItem>> GetAllAsync();

        // Show by Id
        // if is find return ok otherwise null using -> (?)
        Task<ToDoItem?> GetById(Guid id);

        // Update
        Task<ToDoItem?>UpdateAsync(ToDoItem toDoItem);

        // Delete
        Task<ToDoItem?> DeleteAsync(Guid id);
    }
}
