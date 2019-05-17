using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        public CreateRateReviewCommand(AppDbContext context, IMapper mapper, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RateReviewResponse> ExecuteAsync(CreateRateReviewRequest request,Guid userId)
        {
            var rateReview = _mapper.Map<CreateRateReviewRequest, RateReview>(request);
            rateReview.UserWhoGiveMarkId = userId;
            try
            {
                await _context.RateReviews.AddAsync(rateReview);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
            }
            
            return _mapper.Map<RateReview, RateReviewResponse>(rateReview);
        }
    }
}
