using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Recipies
{
    public interface IDeleteRecipeCommand
    {
        Task ExecuteAsync(Guid recipeId);
    }
}
