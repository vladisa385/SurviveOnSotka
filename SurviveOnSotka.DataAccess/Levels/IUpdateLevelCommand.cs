using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Levels;

namespace SurviveOnSotka.DataAccess.Levels
{
    public interface IUpdateLevelCommand
    {
        Task<LevelResponse> ExecuteAsync(Guid cityId, UpdateLevelRequest request);

    }
}
