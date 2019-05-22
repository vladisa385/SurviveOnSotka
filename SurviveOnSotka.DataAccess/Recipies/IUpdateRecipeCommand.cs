using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Implementanion.Recipies;

namespace SurviveOnSotka.DataAccess.Recipies
{
    public interface IUpdateRecipeCommand
    {
        Task<RecipeResponse> ExecuteAsync(UpdateRecipeRequest request);
    }
}
