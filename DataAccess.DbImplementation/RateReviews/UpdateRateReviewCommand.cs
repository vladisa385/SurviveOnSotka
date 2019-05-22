using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.RateReviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReviews
{
    public class UpdateRateReviewCommand : IUpdateRateReviewCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateRateReviewCommand(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RateReviewResponse> ExecuteAsync(UpdateRateReviewRequest request, Guid userId)
        {
            var rateReview = await _context.RateReviews.FirstOrDefaultAsync(u =>
                u.ReviewId == request.ReviewId &&
                u.UserId == userId);
            if(rateReview==null)
                 throw new UpdateItemException("RateReview cannot be updated.ReviewId with this id doesn't exist");
            rateReview.IsCool = request.IsCool;
            await _context.SaveChangesAsync();
            return _mapper.Map<RateReview, RateReviewResponse>(rateReview);
        }
    }
}
