using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace SurviveOnSotka.ViewModel.TypeFoods
{
    public class TypeFoodResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required, MinLength(5), MaxLength(12)]
        public string Name { get; set; }
        public IFormFile Icon { get; set; }
        [Required]
        public int IngredientsCount { get; set; }
    }
}
