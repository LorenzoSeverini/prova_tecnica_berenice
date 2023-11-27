using Microsoft.EntityFrameworkCore;
using ToDoListApp.Server.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoListApp.Server.Repositories.Interface;
using ToDoListApp.Server.Repositories.Implementation;
using ToDoListApp.Server.DbContext.Seeder;


namespace ToDoListApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ToDoListAppDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("TodoListConnectionString"));
            });
            
            builder.Services.AddScoped<ITodoItemRepository, ToDoItemRepository>();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            // cors (technicaly the api now is public) 
            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });

            app.UseAuthorization();

            app.MapControllers();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapFallbackToFile("/index.html");

            // Seed the database -- try to create some data in the database
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<ToDoListAppDbContext>();

                // Call the seeder logic here
                DatabaseSeeder.SeedData(dbContext);
            }

            app.Run();
        }
    }
}
