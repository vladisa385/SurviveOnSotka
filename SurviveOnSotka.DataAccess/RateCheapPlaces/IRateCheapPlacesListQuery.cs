using System.Threading.Tasks;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.RateCheapPlaces;

namespace SurviveOnSotka.DataAccess.RateCheapPlaces
{
    public interface IRateCheapPlacesListQuery
    {
        Task<ListResponse<RateCheapPlaceResponse>> RunAsync(RateCheapPlaceFilter filter, ListOptions options);
    }
}
