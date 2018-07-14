using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class TypeFood : DomainObject
    {
        [Required, MinLength(5), MaxLength(12)]
        public string Name { get; set; }
        [Required]
        public string PathToIcon { get; set; }
    }
}
