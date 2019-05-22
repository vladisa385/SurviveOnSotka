using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Reviews;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Reviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{
    public class ReviewQuery : IReviewQuery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ReviewQuery(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReviewResponse> RunAsync(Guid reviewId)
        {
            var response = await _context.Reviews
                .ProjectTo<ReviewResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.Id == reviewId);
            return response;
        }
    }
}
