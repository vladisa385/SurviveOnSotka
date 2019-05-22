﻿using System;

namespace SurviveOnSotka.ViewModel.Implementanion.IngredientToRecipe
{
    public class IngredientToRecipeFilter
    {
        public Guid Id { get; set; }
        public RangeFilter<int> Amount { get; set; }
        public RangeFilter<int> Price { get; set; }
        public RangeFilter<int> Weight { get; set; }
    }
}
