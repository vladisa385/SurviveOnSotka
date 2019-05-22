﻿using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.TypeFoods;

namespace SurviveOnSotka.DataAccess.TypeFoods
{
    public interface IUpdateTypeFoodCommand
    {
        Task<TypeFoodResponse> ExecuteAsync(UpdateTypeFoodRequest request);

    }
}
