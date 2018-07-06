using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Model.Entities
{
    public class Tag : DomainObject
    {
        [Required, MinLength(5), MaxLength(12)]
        public string Name { get; set; }
    }
}
