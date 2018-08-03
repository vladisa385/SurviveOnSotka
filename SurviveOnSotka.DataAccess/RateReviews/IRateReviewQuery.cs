using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.RateReviews;

namespace SurviveOnSotka.DataAccess.RateReviews
{
    public interface IRateReviewQuery
    {
        Task<RateReviewResponse> RunAsync(Guid reviewId);
    }
}
