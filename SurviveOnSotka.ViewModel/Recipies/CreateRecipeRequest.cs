using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SurviveOnSotka.ViewModel.Implementanion.IngredientToRecipe;
using SurviveOnSotka.ViewModel.Implementanion.Steps;

namespace SurviveOnSotka.ViewModel.Implementanion.Recipies
{
    public class CreateRecipeRequest
    {
        [Required, MinLength(5), MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(1000)]
        public string Description { get; set; }
        public TimeSpan? TimeForCooking { get; set; }
        public TimeSpan? TimeForPreparetion { get; set; }

        public ICollection<CreateIngredientToRecipeRequest> Ingredients { get; set; }
        public ICollection<IFormFile> Photos { get; set; }
        [Required]
        public ICollection<CreateStepRequest> Steps { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}
