using System.Threading.Tasks;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Implementanion.Reviews;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.DataAccess.Reviews
{
    public interface IReviewsListQuery
    {
        Task<ListResponse<ReviewResponse>> RunAsync(ReviewFilter filter, ListOptions options);
    }
}
