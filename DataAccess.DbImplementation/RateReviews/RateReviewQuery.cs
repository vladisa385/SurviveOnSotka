using AutoMapper;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.RateReviews;
using System;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.BaseOperation;

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

        protected override Task<RateReviewResponse> QueryItem(Guid id)
        {
            //var response = await _context.RateReviews
            //    .ProjectTo<RateReviewResponse>(_mapper.ConfigurationProvider)
            //    .FirstOrDefaultAsync(p =>
            //        p.ReviewId == reviewId &&
            //        p.UserId == userId);

            throw new NotImplementedException("Сорян,Кирилл,это еще не сделал)");
        }
    }
}