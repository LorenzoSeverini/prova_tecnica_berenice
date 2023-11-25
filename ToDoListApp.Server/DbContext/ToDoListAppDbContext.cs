using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography.X509Certificates;
using ToDoListApp.Server.Entities;

namespace ToDoListApp.Server.DbContext
{
    public class ToDoListAppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        // Dependencies injcetion configuration
        protected readonly IConfiguration Configuration;

        public ToDoListAppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Connect to PostgreSQL using the connection string from appsettings.json
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("TodoListConnectionString"));
        }

        //TODO ADD DBSETS
        
        // Db set for ToDoItem 
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }   
}
