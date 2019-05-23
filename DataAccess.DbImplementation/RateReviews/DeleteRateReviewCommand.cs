using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CQRSOperation;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.RateReviews;
using System.Threading.Tasks;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReviews
{
    public class DeleteRateReviewCommand : Command<SimpleDeleteRequest, RateReviewResponse>
    {
        private readonly AppDbContext _context;

        public DeleteRateReviewCommand(AppDbContext context) => _context = context;

        protected override async Task<RateReviewResponse> Execute(SimpleDeleteRequest request)
        {
            var rateReviewToDelete = await _context.RateReviews.FirstOrDefaultAsync(p =>
                p.ReviewId == request.Id &&
                p.UserId == request.GetUserId());
            if (rateReviewToDelete == null) return null;
            if (!request.IsLegalAccess(rateReviewToDelete.UserId))
                throw new IllegalAccessException();
            _context.RateReviews.Remove(rateReviewToDelete);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}