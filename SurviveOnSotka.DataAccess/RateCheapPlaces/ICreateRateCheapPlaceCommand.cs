using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.RateCheapPlaces;

namespace SurviveOnSotka.DataAccess.RateCheapPlaces
{
    public interface ICreateRateCheapPlaceCommand
    {
        Task<RateCheapPlaceResponse> ExecuteAsync(Guid cheapPlaceId, CreateRateCheapPlaceRequest request);
    }
}
