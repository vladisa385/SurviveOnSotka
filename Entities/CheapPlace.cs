using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class CheapPlace : DomainObject

    {
        [Required, MinLength(5)]
        public string Name { get; set; }
        [Required, MinLength(200)]
        public string Description { get; set; }
        [Required]
        public City City { get; set; }
        [Required]
        public Guid CityId { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Address { get; set; }
        public string PathToPhotos { get; set; }
    }
}
