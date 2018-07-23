using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.Ingredients
{
    public class CreateIngredientRequest
    {
        [Required, MinLength(5), MaxLength(16)]
        public string Name { get; set; }
        public IFormFile Icon { get; set; }
        public Guid? IdTypeFood { get; set; }
    }
}
