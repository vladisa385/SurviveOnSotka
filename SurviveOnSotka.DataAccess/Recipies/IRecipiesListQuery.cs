using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Recipies;

namespace SurviveOnSotka.DataAccess.Recipies
{
    public interface IRecipiesListQuery
    {
        Task<ListResponse<RecipeResponse>> RunAsync(RecipeFilter filter, ListOptions options);
    }
}
