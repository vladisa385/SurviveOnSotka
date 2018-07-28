using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.RateReviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReview
{
    public class RateReviewsListQuery : IRateReviewsListQuery
    {
        public Task<ListResponse<RateReviewResponse>> RunAsync(RateReviewFilter filter, ListOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
