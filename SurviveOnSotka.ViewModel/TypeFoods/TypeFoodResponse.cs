﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.TypeFoods
{
    public class TypeFoodResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required, MinLength(5), MaxLength(40)]
        public string Name { get; set; }
        public string Icon { get; set; }
        [Required]
        public int IngredientsCount { get; set; }
    }
}
