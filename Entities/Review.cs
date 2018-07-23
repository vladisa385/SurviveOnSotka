using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class Review
    {
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        [Required, MinLength(1), MaxLength(5)]
        public int Rate { get; set; }
        public string PathToPhotos { get; set; }
        public ICollection<RateReview> RateReviews { get; set; }
    }
}
