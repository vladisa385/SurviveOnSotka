using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Implementanion.IngredientToRecipe
{
    public class IngredientToRecipeResponse
    {
        public Guid IngredientId { get; set; }
        [Range(0, int.MaxValue)]
        public int Amount { get; set; }
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
        [Range(0, int.MaxValue)]
        public int Weight { get; set; }
    }
}
