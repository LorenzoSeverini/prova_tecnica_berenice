using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddIsMarkedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMarked",
                table: "ToDoItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMarked",
                table: "ToDoItems");
        }
    }
}
