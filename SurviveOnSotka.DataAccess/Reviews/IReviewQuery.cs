using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Implementanion.Reviews;

namespace SurviveOnSotka.DataAccess.Reviews
{
    public interface IReviewQuery
    {
        Task<ReviewResponse> RunAsync(Guid reviewId);
    }
}
