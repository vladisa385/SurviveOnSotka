using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.RateCheapPlaces;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.RateCheapPlaces;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateCheapPlaces
{
    public class RateCheapPlacesListQuery : IRateCheapPlacesListQuery

    {
        public Task<ListResponse<RateCheapPlaceResponse>> RunAsync(RateCheapPlaceFilter filter, ListOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
