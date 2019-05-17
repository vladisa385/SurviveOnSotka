using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
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
        private readonly IHostingEnvironment _appEnvironment;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CreateReviewCommand(AppDbContext context, IMapper mapper, IHostingEnvironment appEnvironment, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ReviewResponse> ExecuteAsync(CreateReviewRequest request)
        {
            Review review = null;
            User user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var currentRecipe = await _context.Recipes.Include("Reviews").FirstOrDefaultAsync(u => u.Id == request.RecipeId);
            if (currentRecipe != null)
            {
                var currentUser = await _userManager.Users.Include("Reviews").FirstOrDefaultAsync(
                    u => u.Id == user.Id);
                if (_context.Reviews.AnyAsync(
                        u => u.RecipeId == currentRecipe.Id &&
                             u.AuthorId == currentUser.Id).Result == false)
                {
                    review = _mapper.Map<CreateReviewRequest, Review>(request);
                    review.Author = currentUser;
                    currentUser.Reviews.Add(review);
                    review.Recipe = currentRecipe;
                    currentRecipe.Reviews.Add(review);
                    if (request.Photos != null)
                    {
                        review.PathToPhotos = _appEnvironment.WebRootPath + "/Files/Reviews/" + review.Recipe.Name + "/" + review.Author.Id;
                        foreach (var photo in request.Photos)
                        {

                            await CreateFileCommand.ExecuteAsync(photo, review.PathToPhotos);
                        }
                    }
                    await _context.Reviews.AddAsync(review);
                    await _context.SaveChangesAsync();
                }
            }
            return _mapper.Map<Review, ReviewResponse>(review);
        }
    }
}
