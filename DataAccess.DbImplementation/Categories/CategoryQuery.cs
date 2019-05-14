using System;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public CategoryQuery(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryResponse> RunAsync(Guid categoryId)
        {
            CategoryResponse response = await _context.Categories
                .ProjectTo<CategoryResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.Id == categoryId);
            return response;
        }
    }
}
