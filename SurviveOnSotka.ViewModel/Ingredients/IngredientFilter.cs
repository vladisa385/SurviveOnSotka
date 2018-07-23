using System;

namespace SurviveOnSotka.ViewModel.Ingredients
{
    public class IngredientFilter
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public RangeFilter<int> Recipies { get; set; }
    }
}
