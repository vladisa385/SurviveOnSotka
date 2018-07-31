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
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }
        public string PathToPhotos { get; set; }
        public ICollection<RateReview> RateReviews { get; set; }

        public int Likes
        {
            get { return RateReviews.Count(u => u.IsCool == true); }
        }
        public int DisLikes
        {
            get { return RateReviews.Count(u => u.IsCool == false); }
        }
    }
}
