using System.Threading.Tasks;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Levels;

namespace SurviveOnSotka.DataAccess.Levels
{
    public interface ILevelsListQuery
    {
        Task<ListResponse<LevelResponse>> RunAsync(LevelFilter filter, ListOptions options);

    }
}
