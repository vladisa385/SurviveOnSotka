using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurviveOnSotka.Db.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RateCheaplaces_CheapPlaces_CheapPlaceId",
                table: "RateCheaplaces");

            migrationBuilder.DropForeignKey(
                name: "FK_RateCheaplaces_AspNetUsers_UserWhoGiveMarkId",
                table: "RateCheaplaces");

            migrationBuilder.DropForeignKey(
                name: "FK_RateCheaplaces_RateCheaplaces_RateCheapPlaceCheapPlaceId_RateCheapPlaceUserWhoGiveMarkId",
                table: "RateCheaplaces");

            migrationBuilder.DropForeignKey(
                name: "FK_RateReviews_Reviews_ReviewRecipeId_ReviewAuthorId",
                table: "RateReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_AuthorId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_RateReviews_ReviewRecipeId_ReviewAuthorId",
                table: "RateReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RateCheaplaces",
                table: "RateCheaplaces");

            migrationBuilder.DropIndex(
                name: "IX_RateCheaplaces_RateCheapPlaceCheapPlaceId_RateCheapPlaceUserWhoGiveMarkId",
                table: "RateCheaplaces");

            migrationBuilder.DropColumn(
                name: "FirstStepId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "ReviewAuthorId",
                table: "RateReviews");

            migrationBuilder.DropColumn(
                name: "ReviewRecipeId",
                table: "RateReviews");

            migrationBuilder.DropColumn(
                name: "RateCheapPlaceCheapPlaceId",
                table: "RateCheaplaces");

            migrationBuilder.DropColumn(
                name: "RateCheapPlaceUserWhoGiveMarkId",
                table: "RateCheaplaces");

            migrationBuilder.RenameTable(
                name: "RateCheaplaces",
                newName: "RateCheapPlaces");

            migrationBuilder.RenameIndex(
                name: "IX_RateCheaplaces_UserWhoGiveMarkId",
                table: "RateCheapPlaces",
                newName: "IX_RateCheapPlaces_UserWhoGiveMarkId");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Reviews",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RateCheapPlaces",
                table: "RateCheapPlaces",
                columns: new[] { "CheapPlaceId", "UserWhoGiveMarkId" });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RecipeId",
                table: "Reviews",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RateCheapPlaces_CheapPlaces_CheapPlaceId",
                table: "RateCheapPlaces",
                column: "CheapPlaceId",
                principalTable: "CheapPlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RateCheapPlaces_AspNetUsers_UserWhoGiveMarkId",
                table: "RateCheapPlaces",
                column: "UserWhoGiveMarkId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RateReviews_Reviews_ReviewId",
                table: "RateReviews",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_AuthorId",
                table: "Reviews",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RateCheapPlaces_CheapPlaces_CheapPlaceId",
                table: "RateCheapPlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_RateCheapPlaces_AspNetUsers_UserWhoGiveMarkId",
                table: "RateCheapPlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_RateReviews_Reviews_ReviewId",
                table: "RateReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_AuthorId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_RecipeId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RateCheapPlaces",
                table: "RateCheapPlaces");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "RateCheapPlaces",
                newName: "RateCheaplaces");

            migrationBuilder.RenameIndex(
                name: "IX_RateCheapPlaces_UserWhoGiveMarkId",
                table: "RateCheaplaces",
                newName: "IX_RateCheaplaces_UserWhoGiveMarkId");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FirstStepId",
                table: "Recipes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ReviewAuthorId",
                table: "RateReviews",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReviewRecipeId",
                table: "RateReviews",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RateCheapPlaceCheapPlaceId",
                table: "RateCheaplaces",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RateCheapPlaceUserWhoGiveMarkId",
                table: "RateCheaplaces",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                columns: new[] { "RecipeId", "AuthorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RateCheaplaces",
                table: "RateCheaplaces",
                columns: new[] { "CheapPlaceId", "UserWhoGiveMarkId" });

            migrationBuilder.CreateIndex(
                name: "IX_RateReviews_ReviewRecipeId_ReviewAuthorId",
                table: "RateReviews",
                columns: new[] { "ReviewRecipeId", "ReviewAuthorId" });

            migrationBuilder.CreateIndex(
                name: "IX_RateCheaplaces_RateCheapPlaceCheapPlaceId_RateCheapPlaceUserWhoGiveMarkId",
                table: "RateCheaplaces",
                columns: new[] { "RateCheapPlaceCheapPlaceId", "RateCheapPlaceUserWhoGiveMarkId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RateCheaplaces_CheapPlaces_CheapPlaceId",
                table: "RateCheaplaces",
                column: "CheapPlaceId",
                principalTable: "CheapPlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RateCheaplaces_AspNetUsers_UserWhoGiveMarkId",
                table: "RateCheaplaces",
                column: "UserWhoGiveMarkId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RateCheaplaces_RateCheaplaces_RateCheapPlaceCheapPlaceId_RateCheapPlaceUserWhoGiveMarkId",
                table: "RateCheaplaces",
                columns: new[] { "RateCheapPlaceCheapPlaceId", "RateCheapPlaceUserWhoGiveMarkId" },
                principalTable: "RateCheaplaces",
                principalColumns: new[] { "CheapPlaceId", "UserWhoGiveMarkId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RateReviews_Reviews_ReviewRecipeId_ReviewAuthorId",
                table: "RateReviews",
                columns: new[] { "ReviewRecipeId", "ReviewAuthorId" },
                principalTable: "Reviews",
                principalColumns: new[] { "RecipeId", "AuthorId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_AuthorId",
                table: "Reviews",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
