using System.Threading.Tasks;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Implementanion.Recipies;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.DataAccess.Recipies
{
    public interface IRecipiesListQuery
    {
        Task<ListResponse<RecipeResponse>> RunAsync(RecipeFilter filter, ListOptions options);
    }
}
