using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SurviveOnSotka.Db.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Recipes_RecipeId",
                table: "Steps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Steps",
                table: "Steps");

            migrationBuilder.RenameTable(
                name: "Steps",
                newName: "Step");

            migrationBuilder.RenameIndex(
                name: "IX_Steps_RecipeId",
                table: "Step",
                newName: "IX_Step_RecipeId");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimeForPreparetion",
                table: "Recipes",
                nullable: true,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimeForCooking",
                table: "Recipes",
                nullable: true,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Step",
                table: "Step",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Step_Recipes_RecipeId",
                table: "Step",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Step_Recipes_RecipeId",
                table: "Step");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Step",
                table: "Step");

            migrationBuilder.RenameTable(
                name: "Step",
                newName: "Steps");

            migrationBuilder.RenameIndex(
                name: "IX_Step_RecipeId",
                table: "Steps",
                newName: "IX_Steps_RecipeId");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimeForPreparetion",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimeForCooking",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Steps",
                table: "Steps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Recipes_RecipeId",
                table: "Steps",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}