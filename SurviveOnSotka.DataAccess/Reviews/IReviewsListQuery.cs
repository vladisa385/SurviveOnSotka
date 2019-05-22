using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.ViewModels;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Reviews;

namespace SurviveOnSotka.DataAccess.Reviews
{
    public interface IReviewsListQuery
    {
        Task<ListResponse<ReviewResponse>> RunAsync(ReviewFilter filter, ListOptions options);
    }
}
