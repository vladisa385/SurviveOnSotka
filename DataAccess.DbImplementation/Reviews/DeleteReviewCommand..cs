using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Reviews;
using SurviveOnSotka.Db;

namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{
    public class DeleteReviewCommand : IDeleteReviewCommand
    {
        private readonly AppDbContext _context;
        public DeleteReviewCommand(AppDbContext context)
        {
            _context = context;
        }

        public async Task ExecuteAsync(Guid reviewId)
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
