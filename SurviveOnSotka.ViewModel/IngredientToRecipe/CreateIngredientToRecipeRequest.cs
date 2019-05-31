using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Implementanion.IngredientToRecipe
{
    public class CreateIngredientToRecipeRequest
    {
        [Required]
        public Guid IngredientId { get; set; }

        public string Amount { get; set; }

    }
}