using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveOnSotka.ViewModel.IngredientToRecipe
{
    public class IngredientToRecipeFilter
    {
        public Guid Id { get; set; }
        public RangeFilter<int> Amount { get; set; }
        public RangeFilter<int> Price { get; set; }
        public RangeFilter<int> Weight { get; set; }
    }
}
