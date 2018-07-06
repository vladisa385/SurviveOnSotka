using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Model.Entities
{
    public class IngredientToRecipe
    {
        public Guid IdRecipe { get; set; }
        public Guid IdIngredient { get; set; }
        [Required]
        public Recipe Recipe { get; set; }
        [Required]
        public Ingredient Ingredient { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
    }
}
