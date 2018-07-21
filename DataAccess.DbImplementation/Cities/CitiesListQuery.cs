using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Cities;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.Cities;

namespace SurviveOnSotka.DataAccess.DbImplementation.Cities
{
    public class CitiesListQuery : ICitiesListQuery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CitiesListQuery(AppDbContext tasksContext, IMapper mapper)
        {
            _context = tasksContext;
            _mapper = mapper;
        }

        private IQueryable<CityResponse> ApplyFilter(IQueryable<CityResponse> query, CityFilter filter)
        {
            if (filter.Id != null)
            {
                query = query.Where(p => p.Id == filter.Id);
            }

            if (filter.Name != null)
            {
                query = query.Where(p => p.Name.StartsWith(filter.Name));
            }

            if (filter.CheapPlaces != null)
            {
                if (filter.CheapPlaces.From != null)
                {
                    query = query.Where(p => p.CheapPlacesCount >= filter.CheapPlaces.From);
                }

                if (filter.CheapPlaces.To != null)
                {
                    query = query.Where(p => p.CheapPlacesCount <= filter.CheapPlaces.To);
                }
            }
            return query;
        }

        public async Task<ListResponse<CityResponse>> RunAsync(CityFilter filter, ListOptions options)
        {
            IQueryable<CityResponse> query = _context.Cities.Include("CheapPlaces")
                .ProjectTo<CityResponse>();
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<CityResponse>
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
