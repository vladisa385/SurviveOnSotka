using System;

namespace SurviveOnSotka.ViewModel.RateReviews
{
    public class RateReviewFilter
    {
        public Guid? ReviewId { get; set; }
        public bool? IsCool { get; set; }
        public string UserWhoGiveMarkId { get; set; }
    }
}
