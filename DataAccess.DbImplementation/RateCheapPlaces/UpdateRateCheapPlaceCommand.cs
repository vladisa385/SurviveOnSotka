using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.RateCheapPlaces;
using SurviveOnSotka.ViewModel.RateCheapPlaces;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateCheapPlaces
{
    public class UpdateRateCheapPlaceCommand : IUpdateRateCheapPlaceCommand
    {
        public Task<RateCheapPlaceResponse> ExecuteAsync(Guid rateCheapPlaceId, UpdateRateCheapPlaceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
