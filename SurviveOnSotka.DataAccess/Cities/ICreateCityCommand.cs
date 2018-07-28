using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Cities;

namespace SurviveOnSotka.DataAccess.Cities
{
    public interface ICreateCityCommand
    {
        
            Task<CityResponse> ExecuteAsync(CreateCityRequest request);
        
    }
}
