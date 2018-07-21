using System;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.CheapPlaces
{
    public interface IDeleteCheapPlaceCommand
    {
        Task ExecuteAsync(Guid cheapPlaceId);
    }
}
