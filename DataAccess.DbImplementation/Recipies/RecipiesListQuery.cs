using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.Recipies;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Recipies;

namespace SurviveOnSotka.DataAccess.DbImplementation.Recipies
{
    public class RecipiesListQuery:IRecipiesListQuery
    {
        public Task<ListResponse<RecipeResponse>> RunAsync(RecipeFilter filter, ListOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
