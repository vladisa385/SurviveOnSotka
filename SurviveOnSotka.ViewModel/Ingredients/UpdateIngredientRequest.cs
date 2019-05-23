﻿using Microsoft.AspNetCore.Http;
using SurviveOnSotka.ViewModell.Requests;
using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Implementanion.Ingredients
{
    public class UpdateIngredientRequest : Request
    {
        [Required]
        public Guid Id { get; set; }

        [MinLength(3), MaxLength(100)]
        public string Name { get; set; }

        public IFormFile Icon { get; set; }

        [Required]
        public Guid TypeFoodId { get; set; }
    }
}