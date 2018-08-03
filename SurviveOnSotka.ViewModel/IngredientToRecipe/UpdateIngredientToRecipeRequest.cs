using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.IngredientToRecipe
{
    public class UpdateIngredientToRecipeRequest
    {
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        [Range(0, int.MaxValue)]
        public int Amount { get; set; }
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
        [Range(0, int.MaxValue)]
        public int Weight { get; set; }
    }
}

