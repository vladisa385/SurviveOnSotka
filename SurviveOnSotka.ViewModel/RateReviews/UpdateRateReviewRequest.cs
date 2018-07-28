using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.RateReviews
{
    public class UpdateRateReviewRequest
    {
        [Required]
        public bool IsCool { get; set; }
    }
}
