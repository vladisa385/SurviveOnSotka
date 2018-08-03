using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.CheapPlaces;

namespace SurviveOnSotka.DataAccess.CheapPlaces
{
    public interface ICreateCheapPlaceCommand
    {
        Task<CheapPlaceResponse> ExecuteAsync(CreateCheapPlaceRequest request);
    }
}
