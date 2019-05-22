using System.Threading.Tasks;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.DataAccess.Ingredients
{
    public interface IIngredientsListQuery
    {
        Task<ListResponse<IngredientResponse>> RunAsync(IngredientFilter filter, ListOptions options);
    }
}
