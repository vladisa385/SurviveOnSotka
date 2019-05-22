using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;

namespace SurviveOnSotka.DataAccess.Ingredients
{
    public interface IUpdateIngredientCommand
    {
        Task<IngredientResponse> ExecuteAsync(UpdateIngredientRequest request);

    }
}
