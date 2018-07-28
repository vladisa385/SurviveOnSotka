using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.RateCheapPlaces;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateCheapPlaces
{
    public class DeleteRateCheapPlaceCommand : IDeleteRateCheapPlaceCommand

    {
        public Task ExecuteAsync(Guid rateCheapPlaceId)
        {
            throw new NotImplementedException();
        }
    }
}
