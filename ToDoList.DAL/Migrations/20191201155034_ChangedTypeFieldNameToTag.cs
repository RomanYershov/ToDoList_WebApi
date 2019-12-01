using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.DAL.Migrations
{
    public partial class ChangedTypeFieldNameToTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Tags",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
