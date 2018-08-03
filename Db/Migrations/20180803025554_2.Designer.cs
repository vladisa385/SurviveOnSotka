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
    [Migration("20180803025554_2")]
    partial class _2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descriptrion")
                        .HasMaxLength(64);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

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

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid>("CityId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PathToPhotos");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("UserId");

                    b.ToTable("CheapPlaces");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PathToIcon");

                    b.Property<Guid>("TypeFoodId");

                    b.HasKey("Id");

                    b.HasIndex("TypeFoodId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.IngredientToRecipe", b =>
                {
                    b.Property<Guid>("RecipeId");

                    b.Property<Guid>("IngredientId");

                    b.Property<int>("Amount");

                    b.Property<int>("Price");

                    b.Property<int>("Weight");

                    b.HasKey("RecipeId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("IngredientToRecipe");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Level", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("LastLevelId");

                    b.Property<int>("MaxScore");

                    b.Property<int>("MinScore");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<Guid?>("NextLevelId");

                    b.Property<string>("PathToIcon");

                    b.HasKey("Id");

                    b.HasIndex("LastLevelId")
                        .IsUnique()
                        .HasFilter("[LastLevelId] IS NOT NULL");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.RateCheapPlace", b =>
                {
                    b.Property<Guid>("CheapPlaceId");

                    b.Property<string>("UserWhoGiveMarkId");

                    b.Property<bool>("IsCool");

                    b.HasKey("CheapPlaceId", "UserWhoGiveMarkId");

                    b.HasIndex("UserWhoGiveMarkId");

                    b.ToTable("RateCheapPlaces");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.RateReview", b =>
                {
                    b.Property<Guid>("ReviewId");

                    b.Property<string>("UserWhoGiveMarkId");

                    b.Property<bool>("IsCool");

                    b.HasKey("ReviewId", "UserWhoGiveMarkId");

                    b.HasIndex("UserWhoGiveMarkId");

                    b.ToTable("RateReviews");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PathToPhotos");

                    b.Property<TimeSpan>("TimeForCooking");

                    b.Property<TimeSpan>("TimeForPreparetion");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("PathToPhotos");

                    b.Property<int>("Rate");

                    b.Property<Guid>("RecipeId");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Step", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<int>("NumberStep");

                    b.Property<Guid>("RecipeId");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40);

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
                        .HasMaxLength(40);

                    b.Property<string>("PathToIcon");

                    b.HasKey("Id");

                    b.ToTable("TypeFoods");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutYourself")
                        .HasMaxLength(1000);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .HasMaxLength(40);

                    b.Property<bool>("Gender");

                    b.Property<string>("LastName")
                        .HasMaxLength(40);

                    b.Property<Guid?>("LevelId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PathToAvatar");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("LevelId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SurviveOnSotka.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Category", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.Category", "ParentCategory")
                        .WithMany("Categories")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.CheapPlace", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.City", "City")
                        .WithMany("CheapPlaces")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SurviveOnSotka.Entities.User", "User")
                        .WithMany("CheapPlaces")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Ingredient", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.TypeFood", "TypeFood")
                        .WithMany("Ingredients")
                        .HasForeignKey("TypeFoodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.IngredientToRecipe", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.Ingredient", "Ingredient")
                        .WithMany("Recipies")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SurviveOnSotka.Entities.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Level", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.Level", "LastLevel")
                        .WithOne("NextLevel")
                        .HasForeignKey("SurviveOnSotka.Entities.Level", "LastLevelId");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.RateCheapPlace", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.CheapPlace", "CheapPlace")
                        .WithMany("RateCheapPlaces")
                        .HasForeignKey("CheapPlaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SurviveOnSotka.Entities.User", "UserWhoGiveMark")
                        .WithMany("RateCheapPlaces")
                        .HasForeignKey("UserWhoGiveMarkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.RateReview", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.Review", "Review")
                        .WithMany("RateReviews")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SurviveOnSotka.Entities.User", "UserWhoGiveMark")
                        .WithMany("RateReviews")
                        .HasForeignKey("UserWhoGiveMarkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Recipe", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.User", "User")
                        .WithMany("Recipies")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.RecipeInCategories", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.Category", "Category")
                        .WithMany("Recipies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SurviveOnSotka.Entities.Recipe", "Recipe")
                        .WithMany("Categories")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Review", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.User", "Author")
                        .WithMany("Reviews")
                        .HasForeignKey("AuthorId");

                    b.HasOne("SurviveOnSotka.Entities.Recipe", "Recipe")
                        .WithMany("Reviews")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SurviveOnSotka.Entities.Step", b =>
                {
                    b.HasOne("SurviveOnSotka.Entities.Recipe", "Recipe")
                        .WithMany("Steps")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                        .WithMany("Users")
                        .HasForeignKey("LevelId");
                });
#pragma warning restore 612, 618
        }
    }
}
