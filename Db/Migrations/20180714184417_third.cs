﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurviveOnSotka.Db.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 16, nullable: false),
                    Descriptrion = table.Column<string>(maxLength: 64, nullable: true),
                    ParentCategoryId = table.Column<Guid>(nullable: true),
                    PathToIcon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
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
                    MinScore = table.Column<int>(nullable: false),
                    MaxScore = table.Column<int>(nullable: false),
                    LastLevelId = table.Column<Guid>(nullable: true),
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
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NextStepId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PathToPhoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Steps_NextStepId",
                        column: x => x.NextStepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeFoods",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 12, nullable: false),
                    PathToIcon = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeFoods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheapPlaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    AccessFailedCount = table.Column<int>(nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PathToAvatar = table.Column<string>(nullable: true),
                    LevelId = table.Column<Guid>(nullable: false),
                    CurrentScore = table.Column<int>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    AboutYourself = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 12, nullable: false),
                    TypeFoodId = table.Column<Guid>(nullable: true),
                    PathToIcon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_TypeFoods_TypeFoodId",
                        column: x => x.TypeFoodId,
                        principalTable: "TypeFoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AuthorId = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    FirstStepId = table.Column<Guid>(nullable: true),
                    PathToPhotos = table.Column<string>(nullable: true),
                    TimeForCooking = table.Column<DateTime>(nullable: false),
                    TimeForPreparetion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_Steps_FirstStepId",
                        column: x => x.FirstStepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredientToRecipe",
                columns: table => new
                {
                    IdRecipe = table.Column<Guid>(nullable: false),
                    IdIngredient = table.Column<Guid>(nullable: false),
                    RecipeId = table.Column<Guid>(nullable: false),
                    IngredientId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientToRecipe", x => new { x.IdRecipe, x.IdIngredient });
                    table.ForeignKey(
                        name: "FK_IngredientToRecipe_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientToRecipe_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeInCategories",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeInCategories", x => new { x.CategoryId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeInCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeInCategories_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    IdRecipe = table.Column<Guid>(nullable: false),
                    IdUserWhoGiveReview = table.Column<Guid>(nullable: false),
                    RecipeId = table.Column<Guid>(nullable: true),
                    AuthorId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Rate = table.Column<int>(maxLength: 5, nullable: false),
                    PathToPhotos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => new { x.IdRecipe, x.IdUserWhoGiveReview });
                    table.ForeignKey(
                        name: "FK_Reviews_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TagsInRecipe",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(nullable: false),
                    TagId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsInRecipe", x => new { x.TagId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_TagsInRecipe_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagsInRecipe_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RateReviews",
                columns: table => new
                {
                    IdReview = table.Column<Guid>(nullable: false),
                    IdUserWhoGiveMark = table.Column<Guid>(nullable: false),
                    ReviewIdRecipe = table.Column<Guid>(nullable: true),
                    ReviewIdUserWhoGiveReview = table.Column<Guid>(nullable: true),
                    UserWhoGiveMarkId = table.Column<string>(nullable: true),
                    IsCool = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateReviews", x => new { x.IdReview, x.IdUserWhoGiveMark });
                    table.ForeignKey(
                        name: "FK_RateReviews_Users_UserWhoGiveMarkId",
                        column: x => x.UserWhoGiveMarkId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RateReviews_Reviews_ReviewIdRecipe_ReviewIdUserWhoGiveReview",
                        columns: x => new { x.ReviewIdRecipe, x.ReviewIdUserWhoGiveReview },
                        principalTable: "Reviews",
                        principalColumns: new[] { "IdRecipe", "IdUserWhoGiveReview" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CheapPlaces_CityId",
                table: "CheapPlaces",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_TypeFoodId",
                table: "Ingredients",
                column: "TypeFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientToRecipe_IngredientId",
                table: "IngredientToRecipe",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientToRecipe_RecipeId",
                table: "IngredientToRecipe",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Levels_LastLevelId",
                table: "Levels",
                column: "LastLevelId",
                unique: true,
                filter: "[LastLevelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RateReviews_UserWhoGiveMarkId",
                table: "RateReviews",
                column: "UserWhoGiveMarkId");

            migrationBuilder.CreateIndex(
                name: "IX_RateReviews_ReviewIdRecipe_ReviewIdUserWhoGiveReview",
                table: "RateReviews",
                columns: new[] { "ReviewIdRecipe", "ReviewIdUserWhoGiveReview" });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeInCategories_RecipeId",
                table: "RecipeInCategories",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_AuthorId",
                table: "Recipes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_FirstStepId",
                table: "Recipes",
                column: "FirstStepId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AuthorId",
                table: "Reviews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RecipeId",
                table: "Reviews",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_NextStepId",
                table: "Steps",
                column: "NextStepId");

            migrationBuilder.CreateIndex(
                name: "IX_TagsInRecipe_RecipeId",
                table: "TagsInRecipe",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LevelId",
                table: "Users",
                column: "LevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheapPlaces");

            migrationBuilder.DropTable(
                name: "IngredientToRecipe");

            migrationBuilder.DropTable(
                name: "RateReviews");

            migrationBuilder.DropTable(
                name: "RecipeInCategories");

            migrationBuilder.DropTable(
                name: "TagsInRecipe");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "TypeFoods");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Levels");
        }
    }
}
