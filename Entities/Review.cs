using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class Review
    {
        public Guid RecipeId { get; set; }
        public Guid UserWhoGiveReviewId { get; set; }
        public Recipe Recipe { get; set; }
        public User Author { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        [Required, MinLength(1), MaxLength(5)]
        public int Rate { get; set; }
        public string PathToPhotos { get; set; }
    }
}
