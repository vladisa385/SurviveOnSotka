using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.Entities;
using System;

namespace SurviveOnSotka.Db
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RateReview> RateReviews { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TypeFood> TypeFoods { get; set; }
        public DbSet<TagsInRecipe> TagsInRecipies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RateReview>().HasIndex(u => new { u.ReviewId, u.UserId }).IsUnique(); ;
            modelBuilder.Entity<IngredientToRecipe>().HasKey(u => new { u.RecipeId, u.IngredientId });
            modelBuilder.Entity<TagsInRecipe>().HasKey(u => new { u.TagId, u.RecipeId });
        }
    }
}