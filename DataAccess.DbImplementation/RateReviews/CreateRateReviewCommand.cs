using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.RateReviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReviews
{
    public class CreateRateReviewCommand : ICreateRateReviewCommand

    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateRateReviewCommand(AppDbContext context, IMapper mapper, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<RateReviewResponse> ExecuteAsync(Guid reviewId, CreateRateReviewRequest request)
        {
            RateReview rateReview = null;
            User user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var currentReview = await _context.Reviews.Include("RateReviews").FirstOrDefaultAsync(u => u.Id == reviewId);
            if (currentReview != null)
            {
                var currentUser = await _userManager.Users.Include("RateReviews").FirstOrDefaultAsync(
                    u => u.Id == user.Id);
                if (_context.RateReviews.AnyAsync(
                        u => u.ReviewId == currentReview.Id &&
                             u.UserWhoGiveMarkId == currentUser.Id).Result == false)
                {
                    rateReview = _mapper.Map<CreateRateReviewRequest, RateReview>(request);
                    rateReview.UserWhoGiveMark = currentUser;
                    currentUser.RateReviews.Add(rateReview);
                    rateReview.Review = currentReview;
                    currentReview.RateReviews.Add(rateReview);
                    await _context.RateReviews.AddAsync(rateReview);
                    await _context.SaveChangesAsync();
                }
            }
            return _mapper.Map<RateReview, RateReviewResponse>(rateReview);
        }
    }
}
