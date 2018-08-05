using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurviveOnSotka.Db.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagsInRecipe_Recipes_RecipeId",
                table: "TagsInRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_TagsInRecipe_Tags_TagId",
                table: "TagsInRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagsInRecipe",
                table: "TagsInRecipe");

            migrationBuilder.RenameTable(
                name: "TagsInRecipe",
                newName: "TagsInRecipies");

            migrationBuilder.RenameIndex(
                name: "IX_TagsInRecipe_RecipeId",
                table: "TagsInRecipies",
                newName: "IX_TagsInRecipies_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagsInRecipies",
                table: "TagsInRecipies",
                columns: new[] { "TagId", "RecipeId" });

            migrationBuilder.CreateTable(
                name: "TagsInCheapPlaces",
                columns: table => new
                {
                    CheapPlaceId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsInCheapPlaces", x => new { x.TagId, x.CheapPlaceId });
                    table.ForeignKey(
                        name: "FK_TagsInCheapPlaces_CheapPlaces_CheapPlaceId",
                        column: x => x.CheapPlaceId,
                        principalTable: "CheapPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagsInCheapPlaces_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagsInCheapPlaces_CheapPlaceId",
                table: "TagsInCheapPlaces",
                column: "CheapPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagsInRecipies_Recipes_RecipeId",
                table: "TagsInRecipies",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagsInRecipies_Tags_TagId",
                table: "TagsInRecipies",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagsInRecipies_Recipes_RecipeId",
                table: "TagsInRecipies");

            migrationBuilder.DropForeignKey(
                name: "FK_TagsInRecipies_Tags_TagId",
                table: "TagsInRecipies");

            migrationBuilder.DropTable(
                name: "TagsInCheapPlaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagsInRecipies",
                table: "TagsInRecipies");

            migrationBuilder.RenameTable(
                name: "TagsInRecipies",
                newName: "TagsInRecipe");

            migrationBuilder.RenameIndex(
                name: "IX_TagsInRecipies_RecipeId",
                table: "TagsInRecipe",
                newName: "IX_TagsInRecipe_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagsInRecipe",
                table: "TagsInRecipe",
                columns: new[] { "TagId", "RecipeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TagsInRecipe_Recipes_RecipeId",
                table: "TagsInRecipe",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagsInRecipe_Tags_TagId",
                table: "TagsInRecipe",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
