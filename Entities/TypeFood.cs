using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class TypeFood : DomainObject
    {
        [Required, MinLength(5), MaxLength(40)]
        public string Name { get; set; }
        public string PathToIcon { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }

    }
}
