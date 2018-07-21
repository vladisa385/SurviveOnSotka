using System.Threading.Tasks;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Categories;
using SurviveOnSotka.ViewModel.CheapPlaces;

namespace SurviveOnSotka.DataAccess.CheapPlaces
{
    public interface ICheapPlacesListQuery
    {
        Task<ListResponse<CheapPlaceResponse>> RunAsync(CheapPlaceFilter filter, ListOptions options);
    }
}
