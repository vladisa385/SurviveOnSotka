using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel.Recipies;

namespace SurviveOnSotka.DataAccess.Recipies
{
    public interface ICreateRecipeCommand
    {
        Task<RecipeResponse> ExecuteAsync(CreateRecipeRequest request);
    }
}
