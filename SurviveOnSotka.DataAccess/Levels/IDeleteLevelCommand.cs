using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Levels
{
    public interface IDeleteLevelCommand
    {
        Task ExecuteAsync(Guid levelId);
    }
}
