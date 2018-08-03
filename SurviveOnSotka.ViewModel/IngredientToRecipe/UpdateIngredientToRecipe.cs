using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurviveOnSotka.ViewModel.IngredientToRecipe
{
    public class UpdateIngredientToRecipe
    {
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
        [Range(1, int.MaxValue)]
        public int Weight { get; set; }
    }
}

