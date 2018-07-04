using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurviveOnSotka.Entities
{
    public class City : DomainObject
    {
        [Required, MinLength(5)]
        public string Name { get; set; }
    }
}
