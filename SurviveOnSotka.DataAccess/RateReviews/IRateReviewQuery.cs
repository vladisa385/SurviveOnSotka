using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Implementanion.RateReviews;

namespace SurviveOnSotka.DataAccess.RateReviews
{
    public interface IRateReviewQuery
    {
        Task<RateReviewResponse> RunAsync(Guid reviewId,Guid userId);
    }
}
