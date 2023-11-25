using ToDoListApp.Server.Entities;

namespace ToDoListApp.Server.Repositories.Interface
{
    public interface ITodoItemRepository
    {
        Task<ToDoItem> CreateAsync(ToDoItem item);
    }
}
