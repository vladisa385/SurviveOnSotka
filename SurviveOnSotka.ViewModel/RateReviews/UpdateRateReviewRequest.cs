using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.RateReviews
{
    public class UpdateRateReviewRequest
    {
        [Required]
        public Guid ReviewId { get; set; }
        [Required]
        public bool IsCool { get; set; }
    }
}
