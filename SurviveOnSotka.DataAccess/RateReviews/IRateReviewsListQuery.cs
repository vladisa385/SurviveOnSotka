using System.Threading.Tasks;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Implementanion.RateReviews;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.DataAccess.RateReviews
{
    public interface IRateReviewsListQuery
    {
        Task<ListResponse<RateReviewResponse>> RunAsync(RateReviewFilter filter, ListOptions options);
    }
}
