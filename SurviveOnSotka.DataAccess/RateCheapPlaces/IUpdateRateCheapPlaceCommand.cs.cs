using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.RateCheapPlaces;

namespace SurviveOnSotka.DataAccess.RateCheapPlaces
{
    public interface IUpdateRateCheapPlaceCommand
    {
        Task<RateCheapPlaceResponse> ExecuteAsync(Guid cheapPlaceId, UpdateRateCheapPlaceRequest request);
    }
}
