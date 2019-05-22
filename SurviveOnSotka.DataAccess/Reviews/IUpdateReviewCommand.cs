using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Reviews;

namespace SurviveOnSotka.DataAccess.Reviews
{
    public interface IUpdateReviewCommand
    {
        Task<ReviewResponse> ExecuteAsync(UpdateReviewRequest request);
    }
}
