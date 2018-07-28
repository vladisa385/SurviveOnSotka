using System;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.RateCheapPlaces
{
    public interface IDeleteRateCheapPlaceCommand
    {
        Task ExecuteAsync(Guid rateCheapPlaceId);
    }
}
