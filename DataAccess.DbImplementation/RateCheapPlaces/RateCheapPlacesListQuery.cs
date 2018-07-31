using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.RateCheapPlaces;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.RateCheapPlaces;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateCheapPlaces
{
    public class RateCheapPlacesListQuery : IRateCheapPlacesListQuery

    {
        private readonly AppDbContext _context;
        public RateCheapPlacesListQuery(AppDbContext tasksContext)
        {
            _context = tasksContext;

        }

        private IQueryable<RateCheapPlaceResponse> ApplyFilter(IQueryable<RateCheapPlaceResponse> query, RateCheapPlaceFilter filter)
        {

            if (filter.UserWhoGiveMarkId != null)
            {
                query = query.Where(p => p.UserWhoGiveMarkId == filter.UserWhoGiveMarkId);
            }

            if (filter.CheapPlaceId != null)
            {
                query = query.Where(p => p.CheapPlaceId == filter.CheapPlaceId);
            }
            if (filter.IsCool != null)
            {
                query = query.Where(p => p.IsCool == filter.IsCool);
            }
            return query;
        }

        public async Task<ListResponse<RateCheapPlaceResponse>> RunAsync(RateCheapPlaceFilter filter, ListOptions options)
        {
            IQueryable<RateCheapPlaceResponse> query = _context.RateCheapPlaces
                .ProjectTo<RateCheapPlaceResponse>();
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "CheapPlaceId";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<RateCheapPlaceResponse>
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
