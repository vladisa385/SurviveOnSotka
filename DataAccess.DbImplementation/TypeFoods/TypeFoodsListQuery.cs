﻿using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.TypeFoods;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.TypeFoods;

namespace SurviveOnSotka.DataAccess.DbImplementation.TypeFoods
{
    public class TypeFoodsListQuery : ITypeFoodsListQuery
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
            {
                query = query.Where(p => p.Id == filter.Id);
            }

            if (filter.Name != null)
            {
                query = query.Where(p => p.Name.StartsWith(filter.Name));
            }

            if (filter.Ingredients != null)
            {
                if (filter.Ingredients.From != null)
                {
                    query = query.Where(p => p.IngredientsCount >= filter.Ingredients.From);
                }

                if (filter.Ingredients.To != null)
                {
                    query = query.Where(p => p.IngredientsCount <= filter.Ingredients.To);
                }
            }
            return query;
        }

        public async Task<ListResponse<TypeFoodResponse>> RunAsync(TypeFoodFilter filter, ListOptions options)
        {
            IQueryable<TypeFoodResponse> query = _context.TypeFoods.Include("Ingredients")
                .ProjectTo<TypeFoodResponse>(_mapper.ConfigurationProvider);
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<TypeFoodResponse>
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

