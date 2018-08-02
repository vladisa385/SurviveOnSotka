﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.IngredientToRecipe;
using SurviveOnSotka.ViewModel.Steps;

namespace SurviveOnSotka.ViewModel.Recipies
{
    public class CreateRecipeRequest
    {
        [Required, MinLength(5)]
        public string Name { get; set; }
        [Required, MinLength(100)]
        public string Description { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public string PathToPhotos { get; set; }
        public TimeSpan TimeForCooking { get; set; }
        public TimeSpan TimeForPreparetion { get; set; }
        public ICollection<CreateIngredientToRecipeRequest> Ingredients { get; set; }
        public ICollection<IFormFile> Photos { get; set; }
        public ICollection<CreateStepRequest> Steps { get; set; }
    }
}
