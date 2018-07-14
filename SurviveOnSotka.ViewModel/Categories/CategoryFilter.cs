using System;
using System.Collections.Generic;
using System.Text;

namespace SurviveOnSotka.ViewModel.Categories
{
    public class CategoryFilter
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public RangeFilter<int> Recipies { get; set; }
    }
}
