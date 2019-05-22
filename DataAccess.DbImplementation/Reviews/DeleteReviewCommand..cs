using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.DataAccess.Reviews;
using SurviveOnSotka.Db;
using SurviveOnSotka.ViewModel.Implementanion.Reviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{
    public class DeleteReviewCommand : DeleteCommand<ReviewResponse>
    {
        private readonly AppDbContext _context;
        public DeleteReviewCommand(AppDbContext context)
        {
            _context = context;
        }
        protected override async Task DeleteItem(Guid reviewId)
        {
            var reviewToDelete = await _context.Reviews
                .FirstOrDefaultAsync(p => p.Id == reviewId);
            if (reviewToDelete != null)
            {
                _context.Reviews.Remove(reviewToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
