﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurviveOnSotka.Db;

namespace SurviveOnSotka.Db.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180714184417_third")]
    partial class third
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SurviveOnSotka.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descriptrion")
                        .HasMaxLength(64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<Guid?>("ParentCategoryId");

                    b.Property<string>("PathToIcon");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.CheapPlace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<Guid>("CityId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("CheapPlaces");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("PathToIcon");

                    b.Property<Guid?>("TypeFoodId");

                    b.HasKey("Id");

                    b.HasIndex("TypeFoodId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.IngredientToRecipe", b =>
                {
                    b.Property<Guid>("IdRecipe");

                    b.Property<Guid>("IdIngredient");

                    b.Property<int>("Amount");

                    b.Property<Guid>("IngredientId");

                    b.Property<int>("Price");

                    b.Property<Guid>("RecipeId");

                    b.Property<int>("Weight");

                    b.HasKey("IdRecipe", "IdIngredient");

                    b.HasIndex("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("IngredientToRecipe");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Level", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("LastLevelId");

                    b.Property<int>("MaxScore");

                    b.Property<int>("MinScore");

                    b.Property<string>("PathToIcon");

                    b.HasKey("Id");

                    b.HasIndex("LastLevelId")
                        .IsUnique()
                        .HasFilter("[LastLevelId] IS NOT NULL");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.RateReview", b =>
                {
                    b.Property<Guid>("IdReview");

                    b.Property<Guid>("IdUserWhoGiveMark");

                    b.Property<bool>("IsCool");

                    b.Property<Guid?>("ReviewIdRecipe");

                    b.Property<Guid?>("ReviewIdUserWhoGiveReview");

                    b.Property<string>("UserWhoGiveMarkId");

                    b.HasKey("IdReview", "IdUserWhoGiveMark");

                    b.HasIndex("UserWhoGiveMarkId");

                    b.HasIndex("ReviewIdRecipe", "ReviewIdUserWhoGiveReview");

                    b.ToTable("RateReviews");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<Guid?>("FirstStepId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PathToPhotos");

                    b.Property<DateTime>("TimeForCooking");

                    b.Property<DateTime>("TimeForPreparetion");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("FirstStepId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.RecipeInCategories", b =>
                {
                    b.Property<Guid>("CategoryId");

                    b.Property<Guid>("RecipeId");

                    b.HasKey("CategoryId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeInCategories");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Review", b =>
                {
                    b.Property<Guid>("IdRecipe");

                    b.Property<Guid>("IdUserWhoGiveReview");

                    b.Property<string>("AuthorId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("PathToPhotos");

                    b.Property<int>("Rate")
                        .HasMaxLength(5);

                    b.Property<Guid?>("RecipeId");

                    b.Property<string>("Text");

                    b.HasKey("IdRecipe", "IdUserWhoGiveReview");

                    b.HasIndex("AuthorId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Step", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid?>("NextStepId");

                    b.Property<string>("PathToPhoto");

                    b.HasKey("Id");

                    b.HasIndex("NextStepId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.TagsInRecipe", b =>
                {
                    b.Property<Guid>("TagId");

                    b.Property<Guid>("RecipeId");

                    b.HasKey("TagId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("TagsInRecipe");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.TypeFood", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("PathToIcon")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("TypeFoods");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutYourself");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<int>("CurrentScore");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<bool>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<Guid>("LevelId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PathToAvatar");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("LevelId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Category", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.Category", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.CheapPlace", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Ingredient", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.TypeFood", "TypeFood")
                        .WithMany()
                        .HasForeignKey("TypeFoodId");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.IngredientToRecipe", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SurviveOnSotka.Entities.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Level", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.Level", "LastLevel")
                        .WithOne("NextLevel")
                        .HasForeignKey("SurviveOnSotka.Entities.Level", "LastLevelId");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.RateReview", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.User", "UserWhoGiveMark")
                        .WithMany()
                        .HasForeignKey("UserWhoGiveMarkId");

                    b.HasOne("SurviveOnSotka.Entities.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewIdRecipe", "ReviewIdUserWhoGiveReview");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Recipe", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SurviveOnSotka.Entities.Step", "FirstStep")
                        .WithMany()
                        .HasForeignKey("FirstStepId");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.RecipeInCategories", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.Category", "Category")
                        .WithMany("Recipies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SurviveOnSotka.Entities.Recipe", "Recipe")
                        .WithMany("Categorieses")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Review", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("SurviveOnSotka.Entities.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Step", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.Step", "NextStep")
                        .WithMany()
                        .HasForeignKey("NextStepId");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.TagsInRecipe", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.Recipe", "Recipe")
                        .WithMany("Tags")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SurviveOnSotka.Entities.Tag", "Tag")
                        .WithMany("Recipes")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.User", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.Level", "Level")
                        .WithMany()
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
