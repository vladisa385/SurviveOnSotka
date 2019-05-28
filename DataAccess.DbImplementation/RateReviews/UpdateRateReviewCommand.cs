using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.RateReviews;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReviews
{
    public class UpdateRateReviewCommand : Command<UpdateRateReviewRequest, RateReviewResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateRateReviewCommand(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<RateReviewResponse> Execute(UpdateRateReviewRequest request)
        {
            var rateReview = await _context.RateReviews.FirstOrDefaultAsync(u =>
                u.ReviewId == request.ReviewId &&
                u.UserId == request.GetUserId());
            if (rateReview == null)
                throw new UpdateItemException("RateReview cannot be updated.ReviewId with this id doesn't exist");
            if (!request.IsLegalAccess(rateReview.UserId))
                throw new IllegalAccessException();
            rateReview.IsCool = request.IsCool;
            await _context.SaveChangesAsync();
            return _mapper.Map<RateReview, RateReviewResponse>(rateReview);
        }
    }
}