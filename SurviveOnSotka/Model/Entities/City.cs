using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Model.Entities
{
    public class City : DomainObject
    {
        [Required, MinLength(5)]
        public string Name { get; set; }
    }
}
