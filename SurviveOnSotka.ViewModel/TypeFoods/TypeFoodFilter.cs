using SurviveOnSotka.ViewModell;
using System;

namespace SurviveOnSotka.ViewModel.Implementanion.TypeFoods
{
    public class TypeFoodFilter : Filter
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public RangeFilter<int> Ingredients { get; set; }
    }
}