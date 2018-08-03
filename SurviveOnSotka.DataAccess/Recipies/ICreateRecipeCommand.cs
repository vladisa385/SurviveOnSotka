using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Recipies;

namespace SurviveOnSotka.DataAccess.Recipies
{
    public interface ICreateRecipeCommand
    {
        Task<RecipeResponse> ExecuteAsync(CreateRecipeRequest request);
    }
}
