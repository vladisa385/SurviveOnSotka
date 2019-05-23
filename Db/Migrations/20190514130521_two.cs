using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SurviveOnSotka.Db.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Levels_LevelId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "RateCheapPlaces");

            migrationBuilder.DropTable(
                name: "TagsInCheapPlaces");

            migrationBuilder.DropTable(
                name: "CheapPlaces");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LevelId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LastLevelId = table.Column<Guid>(nullable: true),
                    MaxScore = table.Column<int>(nullable: false),
                    MinScore = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    NextLevelId = table.Column<Guid>(nullable: true),
                    PathToIcon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Levels_Levels_LastLevelId",
                        column: x => x.LastLevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheapPlaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PathToPhotos = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheapPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheapPlaces_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheapPlaces_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RateCheapPlaces",
                columns: table => new
                {
                    CheapPlaceId = table.Column<Guid>(nullable: false),
                    UserWhoGiveMarkId = table.Column<Guid>(nullable: false),
                    IsCool = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateCheapPlaces", x => new { x.CheapPlaceId, x.UserWhoGiveMarkId });
                    table.ForeignKey(
                        name: "FK_RateCheapPlaces_CheapPlaces_CheapPlaceId",
                        column: x => x.CheapPlaceId,
                        principalTable: "CheapPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RateCheapPlaces_AspNetUsers_UserWhoGiveMarkId",
                        column: x => x.UserWhoGiveMarkId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagsInCheapPlaces",
                columns: table => new
                {
                    TagId = table.Column<Guid>(nullable: false),
                    CheapPlaceId = table.Column<Guid>(nullable: false)
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
                name: "IX_AspNetUsers_LevelId",
                table: "AspNetUsers",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_CheapPlaces_CityId",
                table: "CheapPlaces",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CheapPlaces_UserId",
                table: "CheapPlaces",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Levels_LastLevelId",
                table: "Levels",
                column: "LastLevelId",
                unique: true,
                filter: "[LastLevelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RateCheapPlaces_UserWhoGiveMarkId",
                table: "RateCheapPlaces",
                column: "UserWhoGiveMarkId");

            migrationBuilder.CreateIndex(
                name: "IX_TagsInCheapPlaces_CheapPlaceId",
                table: "TagsInCheapPlaces",
                column: "CheapPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Levels_LevelId",
                table: "AspNetUsers",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}