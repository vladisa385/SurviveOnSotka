using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.TypeFoods;
using SurviveOnSotka.ViewModell;

namespace SurviveOnSotka.DataAccess.DbImplementation.TypeFoods
{
    public class TypeFoodsListQuery : ListQuery<TypeFoodResponse,TypeFoodFilter>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TypeFoodsListQuery(AppDbContext tasksContext, IMapper mapper)
        {
            _context = tasksContext;
            _mapper = mapper;
        }
        private IQueryable<TypeFoodResponse> ApplyFilter(IQueryable<TypeFoodResponse> query, TypeFoodFilter filter)
        {
            if (filter.Id != null)
                query = query.Where(p => p.Id == filter.Id);

            if (filter.Name != null)
                query = query.Where(p => p.Name.StartsWith(filter.Name));

            if (filter.Ingredients != null)
            {
                if (filter.Ingredients.From != null)
                    query = query.Where(p => p.IngredientsCount >= filter.Ingredients.From);

                if (filter.Ingredients.To != null)
                    query = query.Where(p => p.IngredientsCount <= filter.Ingredients.To);
            }
            return query;
        }
        protected override async Task<ListResponse<TypeFoodResponse>> QueryListItem(TypeFoodFilter filter, ListOptions options)
        {
            var query = _context.TypeFoods
               .Include("Ingredients")
               .ProjectTo<TypeFoodResponse>(_mapper.ConfigurationProvider);
            query = ApplyFilter(query, filter);
            if (options.Sort == null)
                options.Sort = "Id";
            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            var totalCount = await query.CountAsync();
            var items = await query.ToListAsync();
            return new ListResponse<TypeFoodResponse>
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

