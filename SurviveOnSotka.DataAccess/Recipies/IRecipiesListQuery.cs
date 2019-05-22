using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.ViewModels;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Recipies;

namespace SurviveOnSotka.DataAccess.Recipies
{
    public interface IRecipiesListQuery
    {
        Task<ListResponse<RecipeResponse>> RunAsync(RecipeFilter filter, ListOptions options);
    }
}
