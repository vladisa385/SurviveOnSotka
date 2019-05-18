using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Categories;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
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
            var categoryToDelete = await _context.Categories
                .Include(u=>u.Recipies)
                .Include(u=>u.Categories)
                .FirstOrDefaultAsync(p => p.Id == categoryId);
            if (categoryToDelete?.Recipies?.Count > 0)
                throw new DeleteItemCrudException("Category cannot be deleted, if there are recipies in it.");
            if (categoryToDelete?.Categories.Count(u=>u.Id!=categoryToDelete.Id) > 0)
                throw new DeleteItemCrudException("Category cannot be deleted, if there are categories in it.");
            if (categoryToDelete != null)
            {
                _context.Categories.Remove(categoryToDelete);
                await _context.SaveChangesAsync();
            }
        }

    }
}
