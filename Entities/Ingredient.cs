using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class Ingredient : DomainObject
    {
        [Required, MinLength(5), MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public Guid TypeFoodId { get; set; }
        [Required]
        public TypeFood TypeFood { get; set; }
        public string PathToIcon { get; set; }
        public ICollection<IngredientToRecipe> Recipies { get; set; }
    }
}
