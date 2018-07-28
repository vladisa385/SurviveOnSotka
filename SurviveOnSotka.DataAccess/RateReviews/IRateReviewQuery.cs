using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.RateReviews;

namespace SurviveOnSotka.DataAccess.RateReviews
{
    public interface IRateReviewQuery
    {
        Task<RateReviewResponse> RunAsync(Guid rateReviewId);
    }
}
