using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Ingredients;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Ingredients;

namespace SurviveOnSotka.DataAccess.DbImplementation.Ingredients
{
    public class IngredientsListQuery : IIngredientsListQuery
    {
        private readonly AppDbContext _context;
        public IngredientsListQuery(AppDbContext tasksContext)
        {
            _context = tasksContext;

        }

        private IQueryable<IngredientResponse> ApplyFilter(IQueryable<IngredientResponse> query, IngredientFilter filter)
        {
            if (filter.Id != null)
            {
                query = query.Where(p => p.Id == filter.Id);
            }

            if (filter.Name != null)
            {
                query = query.Where(p => p.Name.StartsWith(filter.Name));
            }

            if (filter.Recipies != null)
            {
                if (filter.Recipies.From != null)
                {
                    query = query.Where(p => p.RecipiesCount >= filter.Recipies.From);
                }

                if (filter.Recipies.To != null)
                {
                    query = query.Where(p => p.RecipiesCount <= filter.Recipies.To);
                }
            }
            return query;
        }

        public async Task<ListResponse<IngredientResponse>> RunAsync(IngredientFilter filter, ListOptions options)
        {
            IQueryable<IngredientResponse> query = _context.Ingredients.Include("Recipies")
                .ProjectTo<IngredientResponse>();
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<IngredientResponse>
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

