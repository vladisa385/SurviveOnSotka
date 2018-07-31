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
    public class UpdateRateReviewCommand : IUpdateRateReviewCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateRateReviewCommand(AppDbContext context, IMapper mapper, IHostingEnvironment appEnvironment, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<RateReviewResponse> ExecuteAsync(Guid reviewId, UpdateRateReviewRequest request)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            RateReview rateReview = await _context.RateReviews.FirstOrDefaultAsync(
                u => u.ReviewId == reviewId &&
                     u.UserWhoGiveMarkId == currentUser.Id);
            if (rateReview != null)
            {
                rateReview.IsCool = request.IsCool;
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<RateReview, RateReviewResponse>(rateReview);
        }
    }
}
