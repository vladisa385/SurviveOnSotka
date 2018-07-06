using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Model.Entities
{
    public class TypeFood : DomainObject
    {
        [Required, MinLength(5), MaxLength(12)]
        public string Name { get; set; }
        [Required]
        public FileModel Icon { get; set; }
    }
}
