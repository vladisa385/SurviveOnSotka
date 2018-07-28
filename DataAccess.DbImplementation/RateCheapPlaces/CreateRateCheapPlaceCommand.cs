using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.RateCheapPlaces;
using SurviveOnSotka.ViewModel.RateCheapPlaces;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateCheapPlaces
{
    public class CreateRateCheapPlaceCommand : ICreateRateCheapPlaceCommand
    {
        public Task<RateCheapPlaceResponse> ExecuteAsync(CreateRateCheapPlaceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
