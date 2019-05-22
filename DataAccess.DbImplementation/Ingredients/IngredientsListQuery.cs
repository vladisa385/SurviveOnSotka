using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CQRSOperation;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.Ingredients;

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
        protected override IQueryable<IngredientResponse> ApplyFilter(IQueryable<IngredientResponse> query, IngredientFilter filter)
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

        protected override IQueryable<IngredientResponse> GetQuery() =>
            _context.Ingredients
                .Include("Recipies")
                .ProjectTo<IngredientResponse>(_mapper.ConfigurationProvider);
    }
}

