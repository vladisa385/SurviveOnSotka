using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Levels;

namespace SurviveOnSotka.DataAccess.Levels
{
    public interface ILevelQuery
    {
        Task<LevelResponse> RunAsync(Guid levelId);
    }
}
