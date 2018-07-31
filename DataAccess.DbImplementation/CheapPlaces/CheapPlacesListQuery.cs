using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CheapPlaces;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.CheapPlaces;

namespace SurviveOnSotka.DataAccess.DbImplementation.CheapPlaces
{
    public class CheapPlacesListQuery : ICheapPlacesListQuery
    {
        private readonly AppDbContext _context;
        public CheapPlacesListQuery(AppDbContext tasksContext)
        {
            _context = tasksContext;
        }

        private IQueryable<CheapPlaceResponse> ApplyFilter(IQueryable<CheapPlaceResponse> query, CheapPlaceFilter filter)
        {
            if (filter.Id != null)
            {
                query = query.Where(p => p.Id == filter.Id);
            }

            if (filter.Name != null)
            {
                query = query.Where(p => p.Name.StartsWith(filter.Name));
            }
            if (filter.CityId != null)
            {
                query = query.Where(p => p.CityId == filter.CityId);
            }
            if (filter.Description != null)
            {
                query = query.Where(p => p.Descriptrion.Contains(filter.Description));
            }
            if (filter.Address != null)
            {
                query = query.Where(p => p.Address.Contains(filter.Address));
            }
            if (filter.Likes != null)
            {
                if (filter.Likes.From != null)
                {
                    query = query.Where(p => p.Likes >= filter.Likes.From);
                }

                if (filter.Likes.To != null)
                {
                    query = query.Where(p => p.Likes <= filter.Likes.To);
                }
            }
            if (filter.DisLikes != null)
            {
                if (filter.DisLikes.From != null)
                {
                    query = query.Where(p => p.DisLikes >= filter.DisLikes.From);
                }

                if (filter.DisLikes.To != null)
                {
                    query = query.Where(p => p.DisLikes <= filter.DisLikes.To);
                }
            }
            return query;
        }

        public async Task<ListResponse<CheapPlaceResponse>> RunAsync(CheapPlaceFilter filter, ListOptions options)
        {
            IQueryable<CheapPlaceResponse> query = _context.CheapPlaces.Include("Ingredients")
                .ProjectTo<CheapPlaceResponse>();
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<CheapPlaceResponse>
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

