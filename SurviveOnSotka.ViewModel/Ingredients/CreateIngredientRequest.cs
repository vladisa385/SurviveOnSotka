using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.Implementanion.Ingredients
{
    public class CreateIngredientRequest
    {
        [Required, MinLength(3), MaxLength(100)]
        public string Name { get; set; }
        public IFormFile Icon { get; set; }
        [Required]
        public Guid TypeFoodId { get; set; }
    }
}
