using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class IngredientToRecipe
    {
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
        [Range(0, int.MaxValue)]
        public int Amount { get; set; }
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
        [Range(0, int.MaxValue)]
        public int Weight { get; set; }
    }
}
