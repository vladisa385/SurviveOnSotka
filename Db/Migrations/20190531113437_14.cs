using Microsoft.EntityFrameworkCore.Migrations;

namespace SurviveOnSotka.Db.Migrations
{
    public partial class _14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PathToIcon",
                table: "Ingredients",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "PathToIcon",
                table: "Categories",
                newName: "Icon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Ingredients",
                newName: "PathToIcon");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Categories",
                newName: "PathToIcon");
        }
    }
}
