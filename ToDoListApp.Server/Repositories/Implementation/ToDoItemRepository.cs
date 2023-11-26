using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        // Create new one
        public async Task<ToDoItem> CreateAsync(ToDoItem toDoItem)
        {
            // Injecteted services ( save the changes on database using SaveChangesAsync )
            await dbContext.ToDoItems.AddAsync(toDoItem);
            await dbContext.SaveChangesAsync();

            return toDoItem;
        }

        // Show all
        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            return await dbContext.ToDoItems.ToListAsync();

        }

        public async Task<ToDoItem?> GetById(Guid id)
        {
           // is show to do item if is found, or return null
           return await dbContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
