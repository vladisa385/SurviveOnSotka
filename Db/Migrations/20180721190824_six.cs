using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurviveOnSotka.Db.Migrations
{
    public partial class six : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathToPhotos",
                table: "CheapPlaces",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CheapPlaces",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "CheapPlaces",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheapPlaces_UserId1",
                table: "CheapPlaces",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CheapPlaces_Users_UserId1",
                table: "CheapPlaces",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheapPlaces_Users_UserId1",
                table: "CheapPlaces");

            migrationBuilder.DropIndex(
                name: "IX_CheapPlaces_UserId1",
                table: "CheapPlaces");

            migrationBuilder.DropColumn(
                name: "PathToPhotos",
                table: "CheapPlaces");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CheapPlaces");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "CheapPlaces");
        }
    }
}
