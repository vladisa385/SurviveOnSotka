using System;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Recipies
{
    public interface IDeleteRecipeCommand
    {
        Task ExecuteAsync(Guid recipeId);
    }
}
