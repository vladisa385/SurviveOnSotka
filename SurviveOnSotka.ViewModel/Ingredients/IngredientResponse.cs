﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Ingredients
{
    public class IngredientResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid TypeFoodId { get; set; }
        [Required, MinLength(5), MaxLength(100)]
        public string Name { get; set; }
        public string PathToIcon { get; set; }
        [Required]
        public int RecipiesCount { get; set; }
    }
}
