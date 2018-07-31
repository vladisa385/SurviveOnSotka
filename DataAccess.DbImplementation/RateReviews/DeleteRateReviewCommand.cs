using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReviews
{
    public class DeleteRateReviewCommand : IDeleteRateReviewCommand
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DeleteRateReviewCommand(AppDbContext context, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task ExecuteAsync(Guid reviewId)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            RateReview rateReviewToDelete = await _context.RateReviews.FirstOrDefaultAsync(p => p.ReviewId == reviewId && p.UserWhoGiveMarkId == currentUser.Id);
            if (rateReviewToDelete != null)
            {
                _context.RateReviews.Remove(rateReviewToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
