using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.RateReviews;

namespace SurviveOnSotka.DataAccess.RateReviews
{
    public interface IUpdateRateReviewCommand
    {
        Task<RateReviewResponse> ExecuteAsync(UpdateRateReviewRequest request,Guid userId);
    }
}
