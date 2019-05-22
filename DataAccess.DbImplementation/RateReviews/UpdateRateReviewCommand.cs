﻿using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.RateReviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.RateReviews
{
    public class UpdateRateReviewCommand : Command<UpdateRateReviewRequest,RateReviewResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateRateReviewCommand(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<RateReviewResponse> Execute(UpdateRateReviewRequest request)
        {
            var rateReview = await _context.RateReviews.FirstOrDefaultAsync(u =>
                u.ReviewId == request.ReviewId &&
                u.UserId == request.UserId);
            if(rateReview==null)
                 throw new UpdateItemException("RateReview cannot be updated.ReviewId with this id doesn't exist");
            rateReview.IsCool = request.IsCool;
            await _context.SaveChangesAsync();
            return _mapper.Map<RateReview, RateReviewResponse>(rateReview);
        }
    }
}
