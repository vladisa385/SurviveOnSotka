﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.Ingredients
{
    public class UpdateIngredientRequest
    {
        [MinLength(3), MaxLength(100)]
        public string Name { get; set; }
        public IFormFile Icon { get; set; }
        public Guid? TypeFoodId { get; set; }
    }
}
