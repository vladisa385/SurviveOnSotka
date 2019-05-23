using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class Tag : DomainObject
    {
        [Required, MinLength(3), MaxLength(40)]
        public string Name { get; set; }

        public ICollection<TagsInRecipe> Recipies { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}