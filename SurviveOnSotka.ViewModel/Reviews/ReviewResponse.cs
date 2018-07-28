using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.ViewModel.Reviews
{
    public class ReviewResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid RecipeId { get; set; }
        [Required]
        public string AuthorId { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }
        public string PathToPhotos { get; set; }
        [Required]
        public ICollection<RateReview> RateReviews { get; set; }

        public int? Likes { get; set; }

        public int? DisLikes { get; set; }
    }
}
