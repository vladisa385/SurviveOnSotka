﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.TypeFoods;

namespace SurviveOnSotka.DataAccess.TypeFoods
{
    public interface IUpdateTypeFoodCommand
    {
        Task<TypeFoodResponse> ExecuteAsync(Guid categoryId, UpdateTypeFoodRequest request);

    }
}