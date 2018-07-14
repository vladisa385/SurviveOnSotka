using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Categories;
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
            Category categoryToDelete = _context.Categories.Include("Recipes").FirstOrDefault(p => p.Id == categoryId);
            if (categoryToDelete?.Recipies?.Count > 0)
            {
                throw new CannotDeleteCategoryWithRecipiesException();
            }
            if (categoryToDelete != null)
            {
                _context.Categories.Remove(categoryToDelete);
                await _context.SaveChangesAsync();
            }
        }

    }
}
