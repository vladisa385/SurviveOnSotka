using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SurviveOnSotka.Entities
{
    /// <remarks></remarks>
    public class CheapPlace : DomainObject

    {
        [Required, MinLength(5), MaxLength(100)]
        public string Name { get; set; }
        [Required, MinLength(200), MaxLength(2000)]
        public string Description { get; set; }
        [Required]
        public City City { get; set; }
        [Required]
        public Guid CityId { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
        [Required, MinLength(5), MaxLength(100)]
        public string Address { get; set; }
        public string PathToPhotos { get; set; }
        public ICollection<RateCheapPlace> RateCheapPlaces { get; set; }
        public int Likes
        {
            get
            {
                var sum = 0;
                if (RateCheapPlaces != null)
                    sum += RateCheapPlaces.Count(u => u.IsCool == true);
                return sum;
            }
        }
        public int DisLikes
        {
            get
            {
                var sum = 0;
                if (RateCheapPlaces != null)
                    sum += RateCheapPlaces.Count(u => u.IsCool == false);
                return sum;
            }
        }
    }
}
