using Npgsql.Internal.TypeHandlers;

namespace ToDoListApp.Server.Models.DTO
{
    public class UpdateToDoItemRequestDto
    {
        public string Title { get; set; } = "";

        public string Content { get; set; } = "";

        public bool IsMarked { get; set; } 
    }
}
