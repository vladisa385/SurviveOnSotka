using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.ViewModels;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Ingredients;

namespace SurviveOnSotka.DataAccess.Ingredients
{
    public interface IIngredientsListQuery
    {
        Task<ListResponse<IngredientResponse>> RunAsync(IngredientFilter filter, ListOptions options);
    }
}
