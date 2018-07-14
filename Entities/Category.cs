using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace SurviveOnSotka.Entities
{
    public class Category : DomainObject
    {
        [Required, MinLength(5), MaxLength(16)]
        public string Name { get; set; }
        [MinLength(16), MaxLength(64)]
        public string Descriptrion { get; set; }
        public Category ParentCategory { get; set; }
        public FileModel Icon { get; set; }
        public ICollection<RecipeInCategories> Recipies { get; set; }
        public int RecipiesCount => Recipies?.Count ?? 0;
    }
}
