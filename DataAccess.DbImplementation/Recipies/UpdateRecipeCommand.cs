using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.CheapPlaces;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.DataAccess.Recipies;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Recipies;

namespace SurviveOnSotka.DataAccess.DbImplementation.Recipies
{
    public class UpdateRecipeCommand : IUpdateRecipeCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateRecipeCommand(AppDbContext context, IMapper mapper, IHostingEnvironment appEnvironment, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<RecipeResponse> ExecuteAsync(Guid recipeId, UpdateRecipeRequest request)
        {
            Recipe foundRecipe = await _context.Recipes.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == recipeId);


            if (foundRecipe != null)
            {
                var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var isAdmin = await _userManager.IsInRoleAsync(currentUser, "admin");
                if (foundRecipe.User != currentUser && !isAdmin)
                    throw new ThisRequestNotFromOwnerException();
                Recipe mappedRecipe = _mapper.Map<UpdateRecipeRequest, Recipe>(request);
                mappedRecipe.Id = recipeId;
                _context.Entry(foundRecipe).CurrentValues.SetValues(mappedRecipe);
                if (request.Photos != null)
                {
                    foreach (var photo in request.Photos)
                    {

                        await CreateFileCommand.ExecuteAsync(photo, foundRecipe.PathToPhotos);
                    }
                }
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<Recipe, RecipeResponse>(foundRecipe);
        }
    }
}
