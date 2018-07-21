using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class City : DomainObject
    {
        [Required, MinLength(5)]
        public string Name { get; set; }

        public ICollection<CheapPlace> CheapPlaces { get; set; }

    }
}
