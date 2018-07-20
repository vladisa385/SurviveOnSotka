using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.TypeFoods;

namespace SurviveOnSotka.DataAccess.TypeFoods
{
    public interface ICreateTypeFoodCommand
    {
        Task<TypeFoodResponse> ExecuteAsync(CreateTypeFoodRequest request);
    }
}
