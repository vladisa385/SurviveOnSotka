using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class Category : DomainObject
    {
        [Required, MinLength(5), MaxLength(16)]
        public string Name { get; set; }
        [MinLength(10), MaxLength(64)]
        public string Descriptrion { get; set; }
        public Guid? CategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public string PathToIcon { get; set; }
        public ICollection<RecipeInCategories> Recipies { get; set; }

    }
}
