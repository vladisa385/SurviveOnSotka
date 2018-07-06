using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Model.Entities
{
    public class CheapPlace : DomainObject

    {
        [Required, MinLength(5)]
        public string Name { get; set; }
        [Required, MinLength(200)]
        public string Description { get; set; }
        [Required]
        public City City { get; set; }
        public string Address { get; set; }
    }
}
