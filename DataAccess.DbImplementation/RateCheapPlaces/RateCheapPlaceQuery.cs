using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.RateCheapPlaces;
using SurviveOnSotka.ViewModel.RateCheapPlaces;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateCheapPlaces
{
    public class RateCheapPlaceQuery : IRateCheapPlaceQuery
    {
        public Task<RateCheapPlaceResponse> RunAsync(Guid rateCheapPlaceId)
        {
            throw new NotImplementedException();
        }
    }
}
