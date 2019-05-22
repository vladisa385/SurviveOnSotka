using System;
using System.ComponentModel.DataAnnotations;
using SurviveOnSotka.ViewModell.Requests;

namespace SurviveOnSotka.ViewModel.Implementanion.RateReviews
{
    public class UpdateRateReviewRequest:Request
    {
        [Required]
        public Guid ReviewId { get; set; }
        [Required]
        public bool IsCool { get; set; }
    }
}
