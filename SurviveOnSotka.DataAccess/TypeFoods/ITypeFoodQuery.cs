using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Categories;
using SurviveOnSotka.ViewModel.TypeFoods;

namespace SurviveOnSotka.DataAccess.TypeFoods
{
    public interface ITypeFoodQuery
    {
        Task<TypeFoodResponse> RunAsync(Guid categoryId);
    }
}
