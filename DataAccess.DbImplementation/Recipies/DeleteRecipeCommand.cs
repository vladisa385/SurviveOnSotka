using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.Recipies;

namespace SurviveOnSotka.DataAccess.DbImplementation.Recipies
{
    public class DeleteRecipeCommand:IDeleteRecipeCommand
    {
        public Task ExecuteAsync(Guid recipeId)
        {
            throw new NotImplementedException();
        }
    }
}
