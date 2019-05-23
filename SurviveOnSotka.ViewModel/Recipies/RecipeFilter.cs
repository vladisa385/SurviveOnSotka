using SurviveOnSotka.ViewModel.Implementanion.IngredientToRecipe;
using SurviveOnSotka.ViewModell;
using System;
using System.Collections.Generic;

namespace SurviveOnSotka.ViewModel.Implementanion.Recipies
{
    public class RecipeFilter : Filter
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RangeFilter<int> Categories { get; set; }
        public RangeFilter<int> Reviews { get; set; }
        public Guid? UserId { get; set; }
        public RangeFilter<DateTime> DateCreated { get; set; }
        public RangeFilter<TimeSpan> TimeForCooking { get; set; }
        public RangeFilter<TimeSpan> TimeForPreparetion { get; set; }
        public RangeFilter<int> Rate { get; set; }
        public ICollection<string> Tags { get; set; }
        public ICollection<IngredientToRecipeFilter> Ingredients { get; set; }
    }
}