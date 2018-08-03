using System;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.TypeFoods;

namespace SurviveOnSotka.DataAccess.TypeFoods
{
    public interface ITypeFoodQuery
    {
        Task<TypeFoodResponse> RunAsync(Guid typeFoodId);
    }
}
