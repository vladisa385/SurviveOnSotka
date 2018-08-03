using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Cities;

namespace SurviveOnSotka.DataAccess.Cities
{
    public interface ICityQuery
    {
        Task<CityResponse> RunAsync(Guid cityId);
    }
}
