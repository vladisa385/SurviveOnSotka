using SurviveOnSotka.ViewModell;
using System;
using System.ComponentModel.DataAnnotations;

namespace SurviveOnSotka.ViewModel.Implementanion.RateReviews
{
    public class RateReviewResponse : Response
    {
        public Guid Id { get; set; }
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }

        [Required]
        public bool IsCool { get; set; }
    }
}