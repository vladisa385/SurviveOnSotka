using SurviveOnSotka.ViewModell;
using System;

namespace SurviveOnSotka.ViewModel.Implementanion.Categories
{
    public class CategoryFilter : Filter
    {
        public Guid? Id { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public string Name { get; set; }
        public RangeFilter<int> Recipies { get; set; }

        public RangeFilter<int> Categories { get; set; }
    }
}