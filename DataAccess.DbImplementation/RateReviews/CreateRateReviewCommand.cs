using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CQRSOperation;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.RateReviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReviews
{
    public class CreateRateReviewCommand : Command<CreateRateReviewRequest,RateReviewResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CreateRateReviewCommand(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        protected override async Task<RateReviewResponse> Execute(CreateRateReviewRequest request)
        {
            var rateReview = _mapper.Map<CreateRateReviewRequest, RateReview>(request);
            await _context.RateReviews.AddAsync(rateReview);
            await _context.SaveChangesAsync();
            return _mapper.Map<RateReview, RateReviewResponse>(rateReview);
        }

        protected override void HandleError(Exception exception)
        {
            switch (exception)
            {
                case DbUpdateException _:
                    throw new CreateItemException("RateReview cannot be Created. This rateReview already exist",exception);
            }
            base.HandleError(exception);
        }
    }
}
