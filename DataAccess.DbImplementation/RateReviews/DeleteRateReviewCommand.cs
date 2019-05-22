using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.RateReviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReviews
{
    public class DeleteRateReviewCommand : Command<SimpleDeleteRequest,RateReviewResponse>
    {
        private readonly AppDbContext _context;
        public DeleteRateReviewCommand(AppDbContext context)
        {
            _context = context;
        }

        protected override async Task<RateReviewResponse> Execute(SimpleDeleteRequest request)
        {
            var rateReviewToDelete = await _context.RateReviews.FirstOrDefaultAsync(p =>
                p.ReviewId == request.Id &&
                p.UserId == request.UserId);
            if (rateReviewToDelete == null) return null;
            if (request.IsLegalAccess(rateReviewToDelete.UserId))
                throw new IllegalAccessException();
            _context.RateReviews.Remove(rateReviewToDelete);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
