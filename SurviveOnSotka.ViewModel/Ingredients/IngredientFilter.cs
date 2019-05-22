﻿using System;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.ViewModel.Implementanion.Ingredients
{
    public class IngredientFilter:Filter
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public RangeFilter<int> Recipies { get; set; }
    }
}
