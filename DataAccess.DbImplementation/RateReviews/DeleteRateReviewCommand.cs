using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.RateReviews;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReviews
{
    public class DeleteRateReviewCommand : Command<SimpleDeleteRequest, EmptyResponse<RateReviewResponse>>
    {
        private readonly AppDbContext _context;

        public DeleteRateReviewCommand(AppDbContext context) => _context = context;

        protected override async Task<EmptyResponse<RateReviewResponse>> Execute(SimpleDeleteRequest request)
        {
            var rateReviewToDelete = await _context.RateReviews
                .FirstOrDefaultAsync(p => p.Id == request.Id);
            if (rateReviewToDelete == null)
                return null;
            if (!request.IsLegalAccess(rateReviewToDelete.UserId))
                throw new IllegalAccessException();
            _context.RateReviews.Remove(rateReviewToDelete);
            await _context.SaveChangesAsync();
            return new EmptyResponse<RateReviewResponse>();
        }
    }
}