using System;

namespace SurviveOnSotka.ViewModel.TypeFoods
{
    public class TypeFoodFilter
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public RangeFilter<int> Ingredients { get; set; }
    }
}
