using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CrudOperation;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Reviews;

namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{

    public class CreateReviewCommand : Command<CreateReviewRequest,ReviewResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateReviewCommand(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ReviewResponse> Execute(CreateReviewRequest request)
        {
            var review = _mapper.Map<CreateReviewRequest, Review>(request);
            review.DateCreated = DateTime.Now;
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
