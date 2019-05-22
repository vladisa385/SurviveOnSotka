using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CQRSOperation;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Reviews;


namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{
    public class UpdateReviewCommand : Command<UpdateReviewRequest,ReviewResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateReviewCommand(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ReviewResponse> Execute(UpdateReviewRequest request)
        {
            var foundReview = await _context.Reviews
               .Include(u => u.User)
               .Include(u => u.Recipe)
               .FirstOrDefaultAsync(t => t.Id == request.Id);
            if (foundReview == null)
                throw new UpdateItemException("Review cannot be updated.Review with this id doesn't exist");
            if (!request.IsLegalAccess(foundReview.UserId))
                throw new IllegalAccessException();
            var mappedReview = _mapper.Map<UpdateReviewRequest, Review>(request);
            mappedReview.RecipeId = foundReview.RecipeId;
            mappedReview.UserId = foundReview.UserId;
            mappedReview.DateCreated = foundReview.DateCreated;
            _context.Entry(foundReview).CurrentValues.SetValues(mappedReview);
            await _context.SaveChangesAsync();
            return _mapper.Map<Review, ReviewResponse>(foundReview);
        }
    }
}
