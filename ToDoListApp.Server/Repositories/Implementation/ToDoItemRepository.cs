using ToDoListApp.Server.DbContext;
using ToDoListApp.Server.Entities;
using ToDoListApp.Server.Repositories.Interface;

namespace ToDoListApp.Server.Repositories.Implementation
{
    public class ToDoItemRepository : ITodoItemRepository
    {
        private readonly ToDoListAppDbContext dbContext;

        public ToDoItemRepository(ToDoListAppDbContext dbContext)
        {
            this.dbContext = dbContext;   
        }

        public async Task<ToDoItem> CreateAsync(ToDoItem toDoItem)
        {
            // Injecteted services ( save the changes on database using SaveChangesAsync )
            await dbContext.ToDoItems.AddAsync(toDoItem);
            await dbContext.SaveChangesAsync();

            return toDoItem;
        }
    }
}
