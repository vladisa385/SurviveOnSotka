using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.RateCheapPlaces;

namespace SurviveOnSotka.DataAccess.RateCheapPlaces
{
    public interface IRateCheapPlaceQuery
    {
        Task<RateCheapPlaceResponse> RunAsync(Guid cheapPlaceId);
    }
}
