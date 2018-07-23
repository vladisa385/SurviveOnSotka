using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class Ingredient : DomainObject
    {
        [Required, MinLength(5), MaxLength(12)]
        public string Name { get; set; }
        public Guid? TypeFoodId { get; set; }
        public TypeFood TypeFood { get; set; }
        public string PathToIcon { get; set; }
        public ICollection<Recipe> Recipies { get; set; }
    }
}
