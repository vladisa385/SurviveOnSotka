using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class IngredientToRecipe
    {
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        [Required]
        public Recipe Recipe { get; set; }
        [Required]
        public Ingredient Ingredient { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
    }
}
