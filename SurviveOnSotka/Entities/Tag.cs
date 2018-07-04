using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class Tag : DomainObject
    {
        [Required, MinLength(5), MaxLength(12)]
        public string Name { get; set; }
    }
}
