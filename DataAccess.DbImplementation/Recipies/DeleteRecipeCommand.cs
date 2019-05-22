using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CQRSOperation;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Recipies;

namespace SurviveOnSotka.DataAccess.DbImplementation.Recipies
{
    public class DeleteRecipeCommand : Command<SimpleDeleteRequest,RecipeResponse>
    {
        private readonly AppDbContext _context;
        public DeleteRecipeCommand( AppDbContext context)
        {
            _context = context;
        }
        protected override async Task<RecipeResponse> Execute(SimpleDeleteRequest request)
        {
            var recipeToDelete = await _context.Recipes
                .Include(t => t.User)
                .FirstOrDefaultAsync(p => p.Id == request.Id);
            if (recipeToDelete == null) return null;
            if (!request.IsLegalAccess(recipeToDelete.UserId))
                throw new IllegalAccessException();
            _context.Recipes.Remove(recipeToDelete);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
