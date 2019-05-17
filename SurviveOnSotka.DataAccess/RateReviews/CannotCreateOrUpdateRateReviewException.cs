using System;

namespace SurviveOnSotka.DataAccess.RateReviews
{
    public class CannotCreateOrUpdateRateReviewException : Exception
    {
        public CannotCreateOrUpdateRateReviewException(): base(
            "RateReview cannot be updated or created, This rateReview already exist or review with this id doesn't exist")
        {

        }
    }
}
