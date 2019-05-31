using Microsoft.EntityFrameworkCore.Migrations;

namespace SurviveOnSotka.Db.Migrations
{
    public partial class _13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "IngredientToRecipe");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "IngredientToRecipe");

            migrationBuilder.RenameColumn(
                name: "PathToPhotos",
                table: "Recipes",
                newName: "Photo");

            migrationBuilder.AlterColumn<string>(
                name: "Amount",
                table: "IngredientToRecipe",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Recipes",
                newName: "PathToPhotos");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "IngredientToRecipe",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "IngredientToRecipe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "IngredientToRecipe",
                nullable: false,
                defaultValue: 0);
        }
    }
}
