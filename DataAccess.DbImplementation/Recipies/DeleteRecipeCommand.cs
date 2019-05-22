using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.DataAccess.Recipies;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.Recipies;

namespace SurviveOnSotka.DataAccess.DbImplementation.Recipies
{
    public class DeleteRecipeCommand : DeleteCommand<RecipeResponse>
    {
        private readonly AppDbContext _context;
        public DeleteRecipeCommand( AppDbContext context)
        {
            _context = context;
        }
        protected override async Task DeleteItem(Guid recipeId)
        {
            var recipeToDelete = await _context.Recipes.Include(t => t.User).FirstOrDefaultAsync(p => p.Id == recipeId);
            if (recipeToDelete != null)
            {
                _context.Recipes.Remove(recipeToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
