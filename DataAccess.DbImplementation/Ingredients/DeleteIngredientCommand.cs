using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.DataAccess.Ingredients;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;

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
            Ingredient ingredientToDelete = await _context.Ingredients.FirstOrDefaultAsync(p => p.Id == ingredientId);
            if (ingredientToDelete?.Recipies?.Count > 0)
            {
                throw new CannotDeleteIngredientWithRecipiesExeption();
            }

            if (ingredientToDelete != null)
            {
                if (ingredientToDelete.PathToIcon != null)
                    DeleteFileCommand.Execute(ingredientToDelete.PathToIcon);
                _context.Ingredients.Remove(ingredientToDelete);
                await _context.SaveChangesAsync();
            }
        }

    }
}
