using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.RateReviews;
using System.Linq;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReviews
{
    public class RateReviewsListQuery : ListQuery<RateReviewResponse, RateReviewFilter>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RateReviewsListQuery(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override IQueryable<RateReviewResponse> ApplyFilter(IQueryable<RateReviewResponse> query, RateReviewFilter filter)
        {
            if (filter.UserId != null)
                query = query.Where(p => p.UserId == filter.UserId);
            if (filter.ReviewId != null)
                query = query.Where(p => p.ReviewId == filter.ReviewId);
            if (filter.IsCool != null)
                query = query.Where(p => p.IsCool == filter.IsCool);
            return query;
        }

        protected override IQueryable<RateReviewResponse> GetQuery() =>
            _context.RateReviews
                .ProjectTo<RateReviewResponse>(_mapper.ConfigurationProvider)
                .Include(u => u.UserId)
                .Include(u => u.ReviewId);
    }
}