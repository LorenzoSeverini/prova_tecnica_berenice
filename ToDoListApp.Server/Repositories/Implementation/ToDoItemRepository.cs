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

        // Delete
        public async Task<ToDoItem?> DeleteAsync(Guid id)
        {
            var existingToDoItem = await dbContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
            
            if (existingToDoItem is null) 
            {
                return null;
            }

            // Injecteted services ( save the changes on database using SaveChangesAsync )
            dbContext.ToDoItems.Remove(existingToDoItem);
            await dbContext.SaveChangesAsync();
            return existingToDoItem;
        }

        // Show all
        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            // return all to do items
            return await dbContext.ToDoItems.ToListAsync();
        }

        // Edit
        public async Task<ToDoItem?> GetById(Guid id)
        {
           // is show to do item if is found, or return null
           return await dbContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        // Update
        public async Task<ToDoItem?> UpdateAsync(ToDoItem toDoItem)
        {
            var existingToDoItem = await dbContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == toDoItem.Id);

            if (existingToDoItem != null) 
            {
                dbContext.Entry(existingToDoItem).State = EntityState.Detached; 

                // whit this logic Update only the necessary properties without modifying CreatedAt
                existingToDoItem.Title = toDoItem.Title;
                existingToDoItem.Content = toDoItem.Content;
                existingToDoItem.IsMarked = toDoItem.IsMarked;
                existingToDoItem.UpdatedAt = DateTime.UtcNow; 
                
                // Reattach the entity to the context
                dbContext.Attach(existingToDoItem);                 
                // Mark as modified
                dbContext.Entry(existingToDoItem).State = EntityState.Modified; 
                
                // Save the changes
                await dbContext.SaveChangesAsync();
                return existingToDoItem;
            }

            return null;
        }
    }
}
