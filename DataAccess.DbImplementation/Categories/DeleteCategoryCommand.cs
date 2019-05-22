using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.Categories;
using Task = System.Threading.Tasks.Task;

namespace SurviveOnSotka.DataAccess.DbImplementation.Categories
{
    public class DeleteCategoryCommand : DeleteCommand<CategoryResponse>
    {
        private readonly AppDbContext _context;

        public DeleteCategoryCommand(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        protected override async Task DeleteItem(Guid categoryId)
        {
            var categoryToDelete = await _context.Categories
                .Include(u => u.Recipies)
                .Include(u => u.Categories)
                .FirstOrDefaultAsync(p => p.Id == categoryId);
            if (categoryToDelete?.Recipies?.Count > 0)
                throw new DeleteItemCrudException("Category cannot be deleted, if there are recipies in it.");
            if (categoryToDelete?.Categories.Count(u => u.Id != categoryToDelete.Id) > 0)
                throw new DeleteItemCrudException("Category cannot be deleted, if there are categories in it.");
            if (categoryToDelete != null)
            {
                _context.Categories.Remove(categoryToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
