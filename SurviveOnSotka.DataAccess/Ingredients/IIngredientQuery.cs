using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Ingredients;

namespace SurviveOnSotka.DataAccess.Ingredients
{
    public interface IIngredientQuery
    {
        Task<IngredientResponse> RunAsync(Guid ingredientId);
    }
}
