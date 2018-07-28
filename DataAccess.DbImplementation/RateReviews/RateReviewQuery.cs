using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.ViewModel.RateReviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReview
{
    public class RateReviewQuery : IRateReviewQuery
    {
        public Task<RateReviewResponse> RunAsync(Guid rateReviewId)
        {
            throw new NotImplementedException();
        }
    }
}
