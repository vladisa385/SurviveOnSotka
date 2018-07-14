using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Categories;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using Task = System.Threading.Tasks.Task;

namespace SurviveOnSotka.DataAccess.DbImplementation.Categories
{
    public class DeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly AppDbContext _context;

        public DeleteCategoryCommand(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task ExecuteAsync(Guid categoryId)
        {
            var categories = _context.Categories.ToImmutableList();
            Category categoryToDelete = await _context.Categories.FirstOrDefaultAsync(p => p.Id == categoryId);
            if (categoryToDelete?.Recipies?.Count > 0)
            {
                throw new CannotDeleteCategoryWithRecipiesException();
            }

            if (categoryToDelete != null)
            {
                if (categoryToDelete.PathToIcon != null)
                    DeleteFileCommand.Execute(categoryToDelete.PathToIcon);
                _context.Categories.Remove(categoryToDelete);
                await _context.SaveChangesAsync();
            }
        }

    }
}
