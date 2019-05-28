using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Categories;
using System.Linq;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.DataAccess.DbImplementation.Categories
{
    public class DeleteCategoryCommand : Command<SimpleDeleteRequest, EmptyResponse<CategoryResponse>>
    {
        private readonly AppDbContext _context;

        public DeleteCategoryCommand(AppDbContext dbContext) => _context = dbContext;

        protected override async Task<EmptyResponse<CategoryResponse>> Execute(SimpleDeleteRequest request)
        {
            var categoryToDelete = await _context.Categories
                .Include(u => u.Recipies)
                .Include(u => u.Categories)
                .FirstOrDefaultAsync(p => p.Id == request.Id);
            if (categoryToDelete?.Recipies?.Count > 0)
                throw new DeleteItemException("Category cannot be deleted, if there are recipies in it.");
            if (categoryToDelete?.Categories.Count(u => u.Id != categoryToDelete.Id) > 0)
                throw new DeleteItemException("Category cannot be deleted, if there are categories in it.");
            if (categoryToDelete != null)
            {
                _context.Categories.Remove(categoryToDelete);
                await _context.SaveChangesAsync();
            }
            return new EmptyResponse<CategoryResponse>();
        }
    }
}