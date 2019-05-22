using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.DataAccess.DbImplementation.Ingredients
{
    public class IngredientsListQuery : ListQuery<IngredientResponse,IngredientFilter>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public IngredientsListQuery(AppDbContext tasksContext, IMapper mapper)
        {
            _context = tasksContext;
            _mapper = mapper;
        }
        private IQueryable<IngredientResponse> ApplyFilter(IQueryable<IngredientResponse> query, IngredientFilter filter)
        {
            if (filter.Id != null)
                query = query.Where(p => p.Id == filter.Id);
            if (filter.Name != null)
                query = query.Where(p => p.Name.StartsWith(filter.Name));
            if (filter.Recipies != null)
            {
                if (filter.Recipies.From != null)
                    query = query.Where(p => p.RecipiesCount >= filter.Recipies.From);
                if (filter.Recipies.To != null)
                    query = query.Where(p => p.RecipiesCount <= filter.Recipies.To);
            }
            return query;
        }


        protected override async Task<ListResponse<IngredientResponse>> QueryListItem(IngredientFilter filter, ListOptions options)
        {
            var query = _context.Ingredients
                 .Include("Recipies")
                 .ProjectTo<IngredientResponse>(_mapper.ConfigurationProvider);
            query = ApplyFilter(query, filter);
            if (options.Sort == null)
                options.Sort = "Id";
            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            var totalCount = await query.CountAsync();
            var items = await query.ToListAsync();
            return new ListResponse<IngredientResponse>
            {
                Items = items,
                Page = options.Page,
                PageSize = options.PageSize ?? -1,
                Sort = options.Sort ?? "-Id",
                TotalItemsCount = totalCount
            };
        }
    }
}

