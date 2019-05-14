using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.RateReviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReviews
{
    public class RateReviewQuery : IRateReviewQuery
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public RateReviewQuery(AppDbContext context, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<RateReviewResponse> RunAsync(Guid reviewId)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            RateReviewResponse response = await _context.RateReviews
                .ProjectTo<RateReviewResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.ReviewId == reviewId &&
                                          p.UserWhoGiveMarkId == currentUser.Id
                                          );
            return response;
        }
    }
}
