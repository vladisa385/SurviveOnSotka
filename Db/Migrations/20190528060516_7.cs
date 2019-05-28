using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurviveOnSotka.Db.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RateReviews",
                table: "RateReviews");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "RateReviews",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RateReviews",
                table: "RateReviews",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RateReviews_ReviewId_UserId",
                table: "RateReviews",
                columns: new[] { "ReviewId", "UserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RateReviews",
                table: "RateReviews");

            migrationBuilder.DropIndex(
                name: "IX_RateReviews_ReviewId_UserId",
                table: "RateReviews");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RateReviews");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RateReviews",
                table: "RateReviews",
                columns: new[] { "ReviewId", "UserId" });
        }
    }
}
