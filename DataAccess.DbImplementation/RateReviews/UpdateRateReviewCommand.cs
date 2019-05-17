using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.RateReviews;

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

        public async Task<RateReviewResponse> ExecuteAsync(UpdateRateReviewRequest request,Guid userId)
        {
            try
            {
                var rateReview = await _context.RateReviews.FirstAsync(u =>
                    u.ReviewId == request.ReviewId && 
                    u.UserId == userId);
                rateReview.IsCool = request.IsCool;
                await _context.SaveChangesAsync();
                return _mapper.Map<RateReview, RateReviewResponse>(rateReview);
            }
            catch (DbUpdateException)
            {
                throw new CannotCreateOrUpdateRateReviewException();
            }
        }
    }
}
