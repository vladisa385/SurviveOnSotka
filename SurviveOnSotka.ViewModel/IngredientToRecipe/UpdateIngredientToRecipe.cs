using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveOnSotka.ViewModel.IngredientToRecipe
{
    public class UpdateIngredientToRecipe
    {
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }
    }
}

