using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.ViewModels;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.RateReviews;

namespace SurviveOnSotka.DataAccess.RateReviews
{
    public interface IRateReviewsListQuery
    {
        Task<ListResponse<RateReviewResponse>> RunAsync(RateReviewFilter filter, ListOptions options);
    }
}
