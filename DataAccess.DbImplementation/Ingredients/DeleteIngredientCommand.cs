using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.DataAccess.Ingredients;
using SurviveOnSotka.Db;

namespace SurviveOnSotka.DataAccess.DbImplementation.Ingredients
{
    public class DeleteIngredientCommand : IDeleteIngredientCommand
    {
        private readonly AppDbContext _context;
        public DeleteIngredientCommand(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task ExecuteAsync(Guid ingredientId)
        {
            var ingredientToDelete = await _context.Ingredients
                .Include(u=>u.Recipies)
                .FirstOrDefaultAsync(p => p.Id == ingredientId);
            if (ingredientToDelete?.Recipies?.Count > 0)
                throw new DeleteItemCrudException("Cannot delete ingredient with recipies");
            if (ingredientToDelete != null)
            {
                _context.Ingredients.Remove(ingredientToDelete);
                await _context.SaveChangesAsync();
            }
        }

    }
}
