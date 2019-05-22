using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;

namespace SurviveOnSotka.DataAccess.DbImplementation.Ingredients
{
    public class DeleteIngredientCommand : DeleteCommand<IngredientResponse>
    {
        private readonly AppDbContext _context;
        public DeleteIngredientCommand(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        protected override async Task DeleteItem(Guid ingredientId)
        {
            var ingredientToDelete = await _context.Ingredients
                 .Include(u => u.Recipies)
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
