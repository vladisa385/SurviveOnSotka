using SurviveOnSotka.ViewModel.Implementanion.IngredientToRecipe;
using SurviveOnSotka.ViewModel.Implementanion.Reviews;
using SurviveOnSotka.ViewModel.Implementanion.Steps;
using SurviveOnSotka.ViewModel.Implementanion.TagsInRecipe;
using SurviveOnSotka.ViewModel.Implementanion.Users;
using SurviveOnSotka.ViewModell;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SurviveOnSotka.ViewModel.Implementanion.Categories;

namespace SurviveOnSotka.ViewModel.Implementanion.Recipies
{
    public class RecipeResponse : Response
    {
        public Guid Id { get; set; }

        [Required, MinLength(5), MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(400)]
        public string Description { get; set; }

        [Required]
        public ICollection<ReviewResponse> Reviews { get; set; }

        [Required]
        public CategoryResponse Category { get; set; }

        public UserResponse User { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public string Photo { get; set; }
        public TimeSpan TimeForCooking { get; set; }
        public TimeSpan TimeForPreparetion { get; set; }
        public double Rate => Reviews.Count != 0 ? Reviews.Average(u => u.Rate) : 0;

        public ICollection<IngredientToRecipeResponse> Ingredients { get; set; }

        [Required]
        public ICollection<StepResponse> Steps { get; set; }

        public ICollection<TagsInRecipeResponse> Tags { get; set; }
    }
}