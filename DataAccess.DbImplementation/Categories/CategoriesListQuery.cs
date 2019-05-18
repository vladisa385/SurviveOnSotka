using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Categories;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Categories;

namespace SurviveOnSotka.DataAccess.DbImplementation.Categories
{
    public class CategoriesListQuery : ICategoriesListQuery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CategoriesListQuery(AppDbContext tasksContext, IMapper mapper)
        {
            _context = tasksContext;
            _mapper = mapper;
        }
        private IQueryable<CategoryResponse> ApplyFilter(IQueryable<CategoryResponse> query, CategoryFilter filter)
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
        public async Task<ListResponse<CategoryResponse>> RunAsync(CategoryFilter filter, ListOptions options)
        {
            var query = _context.Categories
                .Include(u=>u.Recipies)
                .ProjectTo<CategoryResponse>(_mapper.ConfigurationProvider);
            query = ApplyFilter(query, filter);
            var totalCount = await query.CountAsync();
            if (options.Sort == null)
                options.Sort = "Id";
            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<CategoryResponse>
            {
                Items = await query.ToListAsync(),
                Page = options.Page,
                PageSize = options.PageSize ?? -1,
                Sort = options.Sort ?? "-Id",
                TotalItemsCount = totalCount
            };
        }
    }
}
