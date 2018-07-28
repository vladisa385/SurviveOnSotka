using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.ViewModel.Recipies
{
    public class RecipeResponse
    {
        public Guid Id { get; set; }
        [Required, MinLength(5)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int CategoriesCount { get; set; }
        [Required]
        public ICollection<Review> Reviews { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public string PathToPhotos { get; set; }
        public ICollection<TagsInRecipe> Tags { get; set; }
        public DateTime TimeForCooking { get; set; }
        public DateTime TimeForPreparetion { get; set; }
        public double Rate
        {
            get
            {
                return Reviews.Average(u => u.Rate);

            }
        }
        public ICollection<IngredientToRecipe> Ingredients { get; set; }
        [Required]
        public ICollection<Step> Steps { get; set; }
    }
}
