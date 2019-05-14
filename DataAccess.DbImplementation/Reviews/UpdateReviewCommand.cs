using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Reviews;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.DataAccess.Users;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Reviews;


namespace SurviveOnSotka.DataAccess.DbImplementation.Reviews
{
    public class UpdateReviewCommand : IUpdateReviewCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateReviewCommand(IHostingEnvironment appEnvironment, AppDbContext context, IMapper mapper, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _appEnvironment = appEnvironment;
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ReviewResponse> ExecuteAsync(Guid reviewId, UpdateReviewRequest request)
        {
            Review foundReview = await _context.Reviews.Include(t => t.Author).Include(t => t.Recipe).FirstOrDefaultAsync(t => t.Id == reviewId);


            if (foundReview != null)
            {
                var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var isAdmin = await _userManager.IsInRoleAsync(currentUser, "admin");
                if (foundReview.Author != currentUser && !isAdmin)
                    throw new ThisRequestNotFromOwnerException(null);
                Review mappedReview = _mapper.Map<UpdateReviewRequest, Review>(request);
                mappedReview.Id = reviewId;
                mappedReview.Author = currentUser;
                mappedReview.AuthorId = currentUser.Id;
                mappedReview.Recipe = foundReview.Recipe;
                mappedReview.RecipeId = foundReview.RecipeId;
                _context.Entry(foundReview).CurrentValues.SetValues(mappedReview);
                if (request.Photos != null)
                {
                    foreach (var photo in request.Photos)
                    {

                        await CreateFileCommand.ExecuteAsync(photo, foundReview.PathToPhotos);
                    }
                }
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<Review, ReviewResponse>(foundReview);
        }
    }
}
