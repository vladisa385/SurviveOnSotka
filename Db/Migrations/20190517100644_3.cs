using Microsoft.EntityFrameworkCore.Migrations;

namespace SurviveOnSotka.Db.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RateReviews_AspNetUsers_UserWhoGiveMarkId",
                table: "RateReviews");

            migrationBuilder.RenameColumn(
                name: "UserWhoGiveMarkId",
                table: "RateReviews",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RateReviews_UserWhoGiveMarkId",
                table: "RateReviews",
                newName: "IX_RateReviews_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RateReviews_AspNetUsers_UserId",
                table: "RateReviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RateReviews_AspNetUsers_UserId",
                table: "RateReviews");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RateReviews",
                newName: "UserWhoGiveMarkId");

            migrationBuilder.RenameIndex(
                name: "IX_RateReviews_UserId",
                table: "RateReviews",
                newName: "IX_RateReviews_UserWhoGiveMarkId");

            migrationBuilder.AddForeignKey(
                name: "FK_RateReviews_AspNetUsers_UserWhoGiveMarkId",
                table: "RateReviews",
                column: "UserWhoGiveMarkId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
