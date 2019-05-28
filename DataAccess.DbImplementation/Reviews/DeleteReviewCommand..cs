using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion;
using SurviveOnSotka.ViewModel.Implementanion.Reviews;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{
    public class DeleteReviewCommand : Command<SimpleDeleteRequest, EmptyResponse<ReviewResponse>>
    {
        private readonly AppDbContext _context;

        public DeleteReviewCommand(AppDbContext context) => _context = context;

        protected override async Task<EmptyResponse<ReviewResponse>> Execute(SimpleDeleteRequest request)
        {
            var reviewToDelete = await _context.Reviews
                .FirstOrDefaultAsync(p => p.Id == request.Id);
            if (reviewToDelete == null) return null;
            if (!request.IsLegalAccess(reviewToDelete.UserId))
                throw new IllegalAccessException();
            _context.Reviews.Remove(reviewToDelete);
            await _context.SaveChangesAsync();
            return new EmptyResponse<ReviewResponse>();
        }
    }
}