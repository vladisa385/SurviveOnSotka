using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class Category : DomainObject
    {
        [Required, MinLength(5), MaxLength(12)]
        public string Name { get; set; }
        public string Descriptrion { get; set; }
        public Category ParentCategory { get; set; }
    }
}
