using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel;
using SurviveOnSotka.ViewModel.RateReviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReviews
{
    public class RateReviewsListQuery : IRateReviewsListQuery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public RateReviewsListQuery(AppDbContext tasksContext, IMapper mapper)
        {
            _context = tasksContext;
            _mapper = mapper;
        }

        private IQueryable<RateReviewResponse> ApplyFilter(IQueryable<RateReviewResponse> query, RateReviewFilter filter)
        {

            if (filter.UserWhoGiveMarkId != null)
            {
                query = query.Where(p => p.UserWhoGiveMarkId == filter.UserWhoGiveMarkId);
            }

            if (filter.ReviewId != null)
            {
                query = query.Where(p => p.ReviewId == filter.ReviewId);
            }
            if (filter.IsCool != null)
            {
                query = query.Where(p => p.IsCool == filter.IsCool);
            }
            return query;
        }

        public async Task<ListResponse<RateReviewResponse>> RunAsync(RateReviewFilter filter, ListOptions options)
        {
            IQueryable<RateReviewResponse> query = _context.RateReviews
                .ProjectTo<RateReviewResponse>(_mapper.ConfigurationProvider);
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "ReviewId";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<RateReviewResponse>
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
