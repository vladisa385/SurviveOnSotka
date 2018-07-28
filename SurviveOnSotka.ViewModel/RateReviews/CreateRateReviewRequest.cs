using System;
using System.ComponentModel.DataAnnotations;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.ViewModel.RateReviews
{
    public class CreateRateReviewRequest
    {
        [Required]
        public bool IsCool { get; set; }
    }
}
