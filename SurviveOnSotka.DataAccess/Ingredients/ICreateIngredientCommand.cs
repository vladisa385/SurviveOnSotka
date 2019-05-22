using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;

namespace SurviveOnSotka.DataAccess.Ingredients
{
    public interface ICreateIngredientCommand
    {
        Task<IngredientResponse> ExecuteAsync(CreateIngredientRequest request);
    }
}
