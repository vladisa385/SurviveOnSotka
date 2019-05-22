using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Users;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.ViewModel.Implementanion.Reviews
{
    public class ReviewResponse:Response
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid RecipeId { get; set; }
        [Required]
        public UserResponse Author { get; set; }
        [Required, MinLength(100), MaxLength(2000)]
        public string Text { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }
        public string PathToPhotos { get; set; }
        [Required]
        public ICollection<RateReview> RateReviews { get; set; }

        public int Likes => RateReviews.Count(u=>u.IsCool);

        public int? DisLikes => RateReviews.Count(u=>u.IsCool == false);
    }
}
