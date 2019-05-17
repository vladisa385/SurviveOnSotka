using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SurviveOnSotka.Entities
{
    public class Review : DomainObject
    {
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public Guid? AuthorId { get; set; }
        public User Author { get; set; }
        [Required, MinLength(100), MaxLength(2000)]
        public string Text { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }
        public string PathToPhotos { get; set; }
        public ICollection<RateReview> RateReviews { get; set; }

        public int Likes
        {
            get
            {
                if (RateReviews == null) return 0;
                return RateReviews.Count(u => u.IsCool);
            }
        }
        public int DisLikes
        {
            get
            {
                if (RateReviews == null) return 0;
                return RateReviews.Count(u => u.IsCool == false);
            }
        }
    }
}
