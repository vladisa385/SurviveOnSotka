using System;
using System.Collections.Generic;
using SurviveOnSotka.ViewModel.IngredientToRecipe;

namespace SurviveOnSotka.ViewModel.Recipies
{
    public class RecipeFilter
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RangeFilter<int> Categories { get; set; }
        public RangeFilter<int> Reviews { get; set; }
        public string UserId { get; set; }
        public RangeFilter<DateTime> DateCreated { get; set; }
        public RangeFilter<TimeSpan> TimeForCooking { get; set; }
        public RangeFilter<TimeSpan> TimeForPreparetion { get; set; }
        public RangeFilter<int> Rate { get; set; }
        public ICollection<CreateIngredientToRecipeRequest> Tags { get; set; }
        public ICollection<string> IdIngredients { get; set; }

    }
}
