using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.RateReviews
{
    public class CreateRateReviewRequest
    {
        [Required]
        public bool IsCool { get; set; }
    }
}
