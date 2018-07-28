using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.ViewModel.RateReviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReview
{
    public class CreateRateReviewCommand:ICreateRateReviewCommand

    {
        public Task<RateReviewResponse> ExecuteAsync(CreateRateReviewRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
