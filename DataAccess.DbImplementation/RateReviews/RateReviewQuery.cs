using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.RateReviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReviews
{
    public class RateReviewQuery : IRateReviewQuery
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
    }
}
