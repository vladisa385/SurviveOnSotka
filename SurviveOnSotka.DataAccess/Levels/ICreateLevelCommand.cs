using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Levels;

namespace SurviveOnSotka.DataAccess.Levels
{
    public interface ICreateLevelCommand
    {
        Task<LevelResponse> ExecuteAsync(CreateLevelRequest request);
    }
}
