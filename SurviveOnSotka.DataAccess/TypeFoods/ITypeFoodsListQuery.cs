using System.Threading.Tasks;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.TypeFoods;

namespace SurviveOnSotka.DataAccess.TypeFoods
{
    public interface ITypeFoodsListQuery
    {
        Task<ListResponse<TypeFoodResponse>> RunAsync(TypeFoodFilter filter, ListOptions options);
    }
}
