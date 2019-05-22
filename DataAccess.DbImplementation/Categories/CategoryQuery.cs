using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CQRSOperation;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.Categories;

namespace SurviveOnSotka.DataAccess.DbImplementation.Categories
{
    public class CategoryQuery : Query<CategoryResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CategoryQuery(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        protected override async Task<CategoryResponse> QueryItem(Guid categoryId)
        {
            var response = await _context.Categories
                .ProjectTo<CategoryResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.Id == categoryId);
            return response;
        }
    }
}
