using System;

namespace SurviveOnSotka.ViewModel.Categories
{
    public class CategoryFilter
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public RangeFilter<int> Recipies { get; set; }
    }
}
