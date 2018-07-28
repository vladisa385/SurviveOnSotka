using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Cities;

namespace SurviveOnSotka.DataAccess.Cities
{
    public interface ICityQuery
    {
        Task<CityResponse> RunAsync(Guid cityId);
    }
}
