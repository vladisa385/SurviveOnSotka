using System;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Cities
{
    public interface IDeleteCityCommand
    {
        Task ExecuteAsync(Guid cityId);
    }
}
