using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.RateReviews
{
    public class RateReviewResponse
    {

        public Guid ReviewId { get; set; }
        public Guid UserWhoGiveMarkId { get; set; }
        [Required]
        public bool IsCool { get; set; }
    }
}
