using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class Tag : DomainObject
    {
        [Required, MinLength(5), MaxLength(40)]
        public string Name { get; set; }
        public ICollection<TagsInRecipe> Recipes { get; set; }
    }
}
