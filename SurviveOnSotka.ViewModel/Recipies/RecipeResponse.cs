using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.IngredientToRecipe;
using SurviveOnSotka.ViewModel.Steps;

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
        public int ReviewsCount { get; set; }
        public User User { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public string PathToPhotos { get; set; }
        public ICollection<TagsInRecipe> Tags { get; set; }
        public TimeSpan TimeForCooking { get; set; }
        public TimeSpan TimeForPreparetion { get; set; }
        public double Rate { get; set; }
        public ICollection<IngredientToRecipeResponce> Ingredients { get; set; }
        [Required]
        public ICollection<StepResponse> Steps { get; set; }
    }
}
