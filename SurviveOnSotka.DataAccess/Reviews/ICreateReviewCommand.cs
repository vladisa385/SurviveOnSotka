using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Implementanion.Reviews;

namespace SurviveOnSotka.DataAccess.Reviews
{
    public interface ICreateReviewCommand
    {
        Task<ReviewResponse> ExecuteAsync(Guid userId,CreateReviewRequest request);
    }
}
