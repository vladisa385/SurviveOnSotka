using System.Threading.Tasks;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Cities;

namespace SurviveOnSotka.DataAccess.Cities
{
    public interface ICitiesListQuery
    {
        Task<ListResponse<CityResponse>> RunAsync(CityFilter filter, ListOptions options);

    }
}
