using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.TypeFoods;

namespace SurviveOnSotka.DataAccess.TypeFoods
{
    public interface ICreateTypeFoodCommand
    {
        Task<TypeFoodResponse> ExecuteAsync(CreateTypeFoodRequest request);
    }
}
