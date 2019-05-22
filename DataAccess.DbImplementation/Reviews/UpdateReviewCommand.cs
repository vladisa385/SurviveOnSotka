using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Reviews;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Reviews;


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
                .Include(u=>u.Author)
                .Include(u=>u.Recipe)
                .FirstOrDefaultAsync(t => t.Id == request.Id);
            if (foundReview == null)
                 throw new UpdateItemException("Review cannot be updated.Review with this id doesn't exist");
            var mappedReview = _mapper.Map<UpdateReviewRequest, Review>(request);
            mappedReview.RecipeId = foundReview.RecipeId;
            mappedReview.AuthorId = foundReview.AuthorId;
            mappedReview.DateCreated = foundReview.DateCreated;
            _context.Entry(foundReview).CurrentValues.SetValues(mappedReview);
            await _context.SaveChangesAsync();
            return _mapper.Map<Review, ReviewResponse>(foundReview);
        }
    }
}
