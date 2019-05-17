using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.IngredientToRecipe;
using SurviveOnSotka.ViewModel.Reviews;
using SurviveOnSotka.ViewModel.Steps;
using SurviveOnSotka.ViewModel.TagsInRecipe;
using SurviveOnSotka.ViewModel.Users;

namespace SurviveOnSotka.ViewModel.Recipies
{
    public class RecipeResponse
    {
        public Guid Id { get; set; }
        [Required, MinLength(5), MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(400)]
        public string Description { get; set; }
        [Required]
        public int CategoriesCount { get; set; }
        [Required]
        public  ICollection<ReviewResponse> Reviews { get; set; }
        public UserResponse User { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public string PathToPhotos { get; set; }
        public TimeSpan TimeForCooking { get; set; }
        public TimeSpan TimeForPreparetion { get; set; }
        public double Rate { get; set; }

        public ICollection<IngredientToRecipeResponse> Ingredients { get; set; }
        [Required]
        public ICollection<StepResponse> Steps { get; set; }

        public ICollection<TagsInRecipeResponse> Tags { get; set; }

    }
}
