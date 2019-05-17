using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.RateReviews;

namespace SurviveOnSotka.DataAccess.RateReviews
{
    public interface ICreateRateReviewCommand
    {
        Task<RateReviewResponse> ExecuteAsync(CreateRateReviewRequest request,Guid UserId);
    }
}
