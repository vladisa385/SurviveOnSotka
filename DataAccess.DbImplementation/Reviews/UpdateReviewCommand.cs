using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Reviews;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Reviews;


namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{
    public class UpdateReviewCommand : IUpdateReviewCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateReviewCommand(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReviewResponse> ExecuteAsync(UpdateReviewRequest request)
        {
            var foundReview = await _context.Reviews
                .FirstOrDefaultAsync(t => t.Id == request.Id);
            if (foundReview == null)
                 throw new UpdateItemException("Review cannot be updated.Review with this id doesn't exist");
            if(foundReview.AuthorId!=request.Id)
                 throw new UpdateItemException("Review cannot be updated.This request doesn't come from owner");
            var mappedReview = _mapper.Map<UpdateReviewRequest, Review>(request);
            _context.Entry(foundReview).CurrentValues.SetValues(mappedReview);
            await _context.SaveChangesAsync();
            return _mapper.Map<Review, ReviewResponse>(foundReview);
        }
    }
}
