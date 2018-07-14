using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Categories;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Categories;

namespace SurviveOnSotka.DataAccess.DbImplementation.Categories
{
    public class CategoryQuery : ICategoryQuery
    {
        private readonly AppDbContext _context;
        public CategoryQuery(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<CategoryResponse> RunAsync(Guid categoryId)
        {
            CategoryResponse response = await _context.Categories
                .ProjectTo<CategoryResponse>()
                .FirstOrDefaultAsync(p => p.Id == categoryId);
            return response;
        }
    }
}
