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
        public Guid? UserId { get; set; }
        public User User { get; set; }

        [Required, MinLength(100), MaxLength(2000)]
        public string Text { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }

        public string Photo { get; set; }
        public ICollection<RateReview> RateReviews { get; set; }

        public int Likes => RateReviews?.Count(u => u.IsCool) ?? 0;

        public int DisLikes => RateReviews?.Count(u => u.IsCool == false) ?? 0;
    }
}