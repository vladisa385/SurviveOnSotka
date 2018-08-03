using System;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Levels
{
    public interface IDeleteLevelCommand
    {
        Task ExecuteAsync(Guid levelId);
    }
}
