using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SurviveOnSotka.Entities;

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
        public DateTime DateCreated { get; set; }
        public DateTime TimeForCooking { get; set; }
        public DateTime TimeForPreparetion { get; set; }
        public RangeFilter<int> Rate { get; set; }
        public ICollection<IngredientToRecipe> Tags { get; set; }
        public ICollection<IngredientToRecipe> Ingredients { get; set; }

    }
}
