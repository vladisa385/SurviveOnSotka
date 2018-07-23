﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Ingredients;

namespace SurviveOnSotka.DataAccess.Ingredients
{
    public interface ICreateIngredientCommand
    {
        Task<IngredientResponse> ExecuteAsync(CreateIngredientRequest request);
    }
}
