using SurviveOnSotka.ViewModell;
using System;

namespace SurviveOnSotka.ViewModel.Implementanion.RateReviews
{
    public class RateReviewFilter : Filter
    {
        public Guid? Id { get; set; }
        public Guid? ReviewId { get; set; }
        public bool? IsCool { get; set; }
        public Guid? UserId { get; set; }
    }
}