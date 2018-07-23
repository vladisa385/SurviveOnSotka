using System;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.Ingredients
{
    public interface IDeleteIngredientCommand
    {
        Task ExecuteAsync(Guid ingredientId);
    }
}
