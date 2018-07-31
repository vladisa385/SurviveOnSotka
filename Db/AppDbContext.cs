using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.Db
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<CheapPlace> CheapPlaces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<RateReview> RateReviews { get; set; }
        public DbSet<RateCheapPlace> RateCheapPlaces { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<TypeFood> TypeFoods { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RateReview>().HasKey(u => new { u.ReviewId, u.UserWhoGiveMarkId });
            modelBuilder.Entity<RateCheapPlace>().HasKey(u => new { u.CheapPlaceId, u.UserWhoGiveMarkId });
            modelBuilder.Entity<IngredientToRecipe>().HasKey(u => new { u.RecipeId, u.IngredientId });
            modelBuilder.Entity<RecipeInCategories>().HasKey(u => new { u.CategoryId, u.RecipeId });
            modelBuilder.Entity<TagsInRecipe>().HasKey(u => new { u.TagId, u.RecipeId });


        }
    }
}
