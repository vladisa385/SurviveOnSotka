using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.DataAccess.RateReviews;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.RateReviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReviews
{
    public class CreateRateReviewCommand : ICreateRateReviewCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CreateRateReviewCommand(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RateReviewResponse> ExecuteAsync(CreateRateReviewRequest request,Guid userId)
        {
            var rateReview = _mapper.Map<CreateRateReviewRequest, RateReview>(request);
            rateReview.UserId = userId;
            try
            {
                await _context.RateReviews.AddAsync(rateReview);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new CreateItemException("RateReview cannot be Created. This rateReview already exist",exception);
            }
            return _mapper.Map<RateReview, RateReviewResponse>(rateReview);
        }
    }
}
