using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SurviveOnSotka.Entities
{
    /// <remarks></remarks>
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
        [Required]
        public string UserId { get; set; }
        [Required]
        public User User { get; set; }
        public string Address { get; set; }
        public string PathToPhotos { get; set; }
        public ICollection<RateCheapPlace> RateCheapPlaces { get; set; }
        public int Likes
        {
            get { return RateCheapPlaces.Count(u => u.IsCool == true); }
        }
        public int DisLikes
        {
            get { return RateCheapPlaces.Count(u => u.IsCool == false); }
        }
    }
}
