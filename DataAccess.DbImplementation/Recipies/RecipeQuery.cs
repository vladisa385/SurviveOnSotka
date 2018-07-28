using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.Recipies;
using SurviveOnSotka.ViewModel.Recipies;

namespace SurviveOnSotka.DataAccess.DbImplementation.Recipies
{
    public class RecipeQuery:IRecipeQuery
    {
        public Task<RecipeResponse> RunAsync(Guid recipeId)
        {
            throw new NotImplementedException();
        }
    }
}
