using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CQRSOperation;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.RateReviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReviews
{
    public class RateReviewQuery : Query<RateReviewResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public RateReviewQuery(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RateReviewResponse> RunAsync(Guid reviewId, Guid userId)
        {
            var response = await _context.RateReviews
                .ProjectTo<RateReviewResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => 
                    p.ReviewId == reviewId &&
                    p.UserId == userId);
            return response;
        }

        protected override Task<RateReviewResponse> QueryItem(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
