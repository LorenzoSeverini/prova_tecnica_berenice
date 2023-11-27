using Microsoft.EntityFrameworkCore;
using ToDoListApp.Server.Entities;

namespace ToDoListApp.Server.DbContext.Seeder
{
    public class DatabaseSeeder
    {
        public static void SeedData(ToDoListAppDbContext context)
        {
            // Check if the database is already seeded
            if (!context.ToDoItems.Any())
            {
                // Seed initial ToDoItems
                var todoItems = new[]
                {
                    new ToDoItem { Title = "Task 1", Content = "Content 1", IsMarked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                    new ToDoItem { Title = "Task 2", Content = "Content 2", IsMarked = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                    new ToDoItem { Title = "Task 3", Content = "Content 3", IsMarked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                    new ToDoItem { Title = "Task 4", Content = "Content 4", IsMarked = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                    new ToDoItem { Title = "Task 5", Content = "Content 5", IsMarked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                };

                // Add ToDoItems to the database
                context.ToDoItems.AddRange(todoItems);
                context.SaveChanges();
            }
        }
    }
}
