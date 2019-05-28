using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.DataAccess.DbImplementation.Ingredients
{
    public class DeleteIngredientCommand : Command<SimpleDeleteRequest, EmptyResponse<IngredientResponse>>
    {
        private readonly AppDbContext _context;

        public DeleteIngredientCommand(AppDbContext dbContext) => _context = dbContext;

        protected override async Task<EmptyResponse<IngredientResponse>> Execute(SimpleDeleteRequest request)
        {
            var ingredientToDelete = await _context.Ingredients
                 .Include(u => u.Recipies)
                 .FirstOrDefaultAsync(p => p.Id == request.Id);
            if (ingredientToDelete?.Recipies?.Count > 0)
                throw new DeleteItemException("Cannot delete ingredient with recipies");
            if (ingredientToDelete != null)
            {
                _context.Ingredients.Remove(ingredientToDelete);
                await _context.SaveChangesAsync();
            }
            return new EmptyResponse<IngredientResponse>();
        }
    }
}