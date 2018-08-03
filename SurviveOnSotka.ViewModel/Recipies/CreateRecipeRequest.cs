﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SurviveOnSotka.ViewModel.IngredientToRecipe;
using SurviveOnSotka.ViewModel.Steps;

namespace SurviveOnSotka.ViewModel.Recipies
{
    public class CreateRecipeRequest
    {
        [Required, MinLength(5), MaxLength(100)]
        public string Name { get; set; }
        [Required, MinLength(100), MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public string PathToPhotos { get; set; }
        public TimeSpan TimeForCooking { get; set; }
        public TimeSpan TimeForPreparetion { get; set; }
        [Required]
        public ICollection<CreateIngredientToRecipeRequest> Ingredients { get; set; }
        public ICollection<IFormFile> Photos { get; set; }
        [Required]
        public ICollection<CreateStepRequest> Steps { get; set; }
    }
}
