using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.TypeFoods;

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

        protected override IQueryable<TypeFoodResponse> ApplyFilter(IQueryable<TypeFoodResponse> query, TypeFoodFilter filter)
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

        protected override IQueryable<TypeFoodResponse> GetQuery()
        {
            var query = _context.TypeFoods
                .Include("Ingredients")
                .ProjectTo<TypeFoodResponse>(_mapper.ConfigurationProvider);
            return query;
        }
    }
}

