using System;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.ViewModel.Implementanion.RateReviews
{
    public class RateReviewFilter:Filter
    {
        public Guid? ReviewId { get; set; }
        public bool? IsCool { get; set; }
        public Guid? UserId { get; set; }
    }
}
