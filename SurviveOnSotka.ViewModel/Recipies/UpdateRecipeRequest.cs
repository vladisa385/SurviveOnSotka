using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SurviveOnSotka.ViewModel.IngredientToRecipe;
using SurviveOnSotka.ViewModel.Steps;

namespace SurviveOnSotka.ViewModel.Recipies
{
    public class UpdateRecipeRequest
    {

        [Required, MinLength(5), MaxLength(100)]
        public string Name { get; set; }
        [Required, MinLength(100), MaxLength(400)]
        public string Description { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public string PathToPhotos { get; set; }
        public TimeSpan TimeForCooking { get; set; }
        public TimeSpan TimeForPreparetion { get; set; }
        public ICollection<UpdateIngredientToRecipeRequest> Ingredients { get; set; }
        public ICollection<IFormFile> Photos { get; set; }
        public ICollection<UpdateStepRequest> Steps { get; set; }
    }
}
