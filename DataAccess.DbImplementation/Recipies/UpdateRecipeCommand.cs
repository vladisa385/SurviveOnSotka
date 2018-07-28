using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.Recipies;
using SurviveOnSotka.ViewModel.Recipies;

namespace SurviveOnSotka.DataAccess.DbImplementation.Recipies
{
    public class UpdateRecipeCommand:IUpdateRecipeCommand
    {
        public Task<RecipeResponse> ExecuteAsync(Guid recipeId, UpdateRecipeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
