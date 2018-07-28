using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.Recipies;
using SurviveOnSotka.ViewModel.Recipies;

namespace SurviveOnSotka.DataAccess.DbImplementation.Recipies
{
    public class CreateRecipeCommand:ICreateRecipeCommand
    {
        public Task<RecipeResponse> ExecuteAsync(CreateRecipeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
