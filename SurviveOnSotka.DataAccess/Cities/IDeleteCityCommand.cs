using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Cities
{
    public interface IDeleteCityCommand
    {
        Task ExecuteAsync(Guid cityId);
    }
}
