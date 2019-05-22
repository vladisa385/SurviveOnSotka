using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SurviveOnSotka.ViewModel.Implementanion.IngredientToRecipe;
using SurviveOnSotka.ViewModel.Implementanion.Steps;
using SurviveOnSotka.ViewModell.Requests;

namespace SurviveOnSotka.ViewModel.Implementanion.Recipies
{
    public class UpdateRecipeRequest:Request
    {

        [Required]
        public Guid Id { get; set; }
        [MinLength(5), MaxLength(100)]
        public string Name { get; set; }
        [MinLength(100), MaxLength(400)]
        public string Description { get; set; }
        public string PathToPhotos { get; set; }
        public TimeSpan? TimeForCooking { get; set; }
        public TimeSpan? TimeForPreparetion { get; set; }
        public ICollection<UpdateIngredientToRecipeRequest> Ingredients { get; set; }
        public ICollection<IFormFile> Photos { get; set; }
        public ICollection<UpdateStepRequest> Steps { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}
