using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.Entities
{
    public class RateReview
    {
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }
        public Review Review { get; set; }
        public User User { get; set; }

        [Required]
        public bool IsCool { get; set; }
    }
}