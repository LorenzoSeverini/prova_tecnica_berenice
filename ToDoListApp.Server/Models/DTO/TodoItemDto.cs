namespace ToDoListApp.Server.Models.DTO
{
    public class TodoItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";

        public bool IsMarked { get; set; } = false;

        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; } 

    }
}
