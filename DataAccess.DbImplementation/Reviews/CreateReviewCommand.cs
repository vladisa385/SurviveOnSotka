using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.DataAccess.Reviews;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Reviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{

    public class CreateReviewCommand : ICreateReviewCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateReviewCommand(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReviewResponse> ExecuteAsync(CreateReviewRequest request)
        {
            var review = _mapper.Map<CreateReviewRequest, Review>(request);
            try
            {
                await _context.Reviews.AddAsync(review);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                throw new CreateItemException("Review cannot be Created. User can create only one review", exception);
            }
            return _mapper.Map<Review, ReviewResponse>(review);
        }
    }
}
