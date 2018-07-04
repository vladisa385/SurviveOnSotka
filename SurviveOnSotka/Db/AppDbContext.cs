using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.Db
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<CheapPlace> CheapPlaces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<FileModel> FileModels { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<RateReview> RateReviews { get; set; }
        public DbSet<Quantity> Quantities { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<TypeFood> TypeFoods { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RateReview>().HasKey(u => new { u.IdReview, u.IdUserWhoGiveMark });
            modelBuilder.Entity<Like>().HasKey(u => new { u.IdRecipe, u.IdUserWhoGiveLike });
        }
    }
}
