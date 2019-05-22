using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.ViewModel.Implementanion.Ingredients
{
    public class CreateIngredientRequest:CreateRequest
    {
        [Required, MinLength(3), MaxLength(100)]
        public string Name { get; set; }
        public IFormFile Icon { get; set; }
        [Required]
        public Guid TypeFoodId { get; set; }
    }
}
