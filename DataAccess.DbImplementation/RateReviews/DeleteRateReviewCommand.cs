using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReviews
{
    public class DeleteRateReviewCommand : IDeleteRateReviewCommand
    {
        private readonly AppDbContext _context;
        public DeleteRateReviewCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task ExecuteAsync(Guid reviewId, Guid userId)
        {
            var rateReviewToDelete = await _context.RateReviews.FirstOrDefaultAsync(p => 
                p.ReviewId == reviewId &&
                p.UserId == userId);
            if (rateReviewToDelete != null)
            {
                _context.RateReviews.Remove(rateReviewToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
