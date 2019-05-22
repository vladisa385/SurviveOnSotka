using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CQRSOperation;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.Categories;

namespace SurviveOnSotka.DataAccess.DbImplementation.Categories
{
    public class CategoriesListQuery : ListQuery<CategoryResponse,CategoryFilter>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CategoriesListQuery(AppDbContext tasksContext, IMapper mapper)
        {
            _context = tasksContext;
            _mapper = mapper;
        }
        protected override IQueryable<CategoryResponse> ApplyFilter(IQueryable<CategoryResponse> query, CategoryFilter filter)
        {
            if (filter.Id != null)
                query = query.Where(p => p.Id == filter.Id);

            if (filter.ParentCategoryId != null)
                query = query.Where(p => p.ParentCategoryId == filter.ParentCategoryId);


            if (filter.Name != null)
                query = query.Where(p => p.Name.StartsWith(filter.Name));

            if (filter.Recipies != null)
            {
                if (filter.Recipies.From != null)
                    query = query.Where(p => p.RecipiesCount >= filter.Recipies.From);

                if (filter.Recipies.To != null)
                    query = query.Where(p => p.RecipiesCount <= filter.Recipies.To);
            }
            if (filter.Categories != null)
            {
                if (filter.Categories.From != null)
                    query = query.Where(p => p.CategoriesCount >= filter.Categories.From);

                if (filter.Categories.To != null)
                    query = query.Where(p => p.CategoriesCount <= filter.Categories.To);
            }
            return query;
        }

        protected override IQueryable<CategoryResponse> GetQuery() =>
            _context.Categories
                .Include(u => u.Recipies)
                .ProjectTo<CategoryResponse>(_mapper.ConfigurationProvider);
    }
}
