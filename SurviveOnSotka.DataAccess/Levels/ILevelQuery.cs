using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Levels;
using SurviveOnSotka.ViewModel.TypeFoods;

namespace SurviveOnSotka.DataAccess.Levels
{
    public interface ILevelQuery
    {
        Task<LevelResponse> RunAsync(Guid levelId);
    }
}
