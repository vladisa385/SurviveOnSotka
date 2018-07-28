using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.ViewModel.RateReviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReview
{
    public class UpdateRateReviewCommand : IUpdateRateReviewCommand
    {
        public Task<RateReviewResponse> ExecuteAsync(Guid rateReviewId, UpdateRateReviewRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
