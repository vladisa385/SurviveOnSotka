using System;
using System.Collections.Generic;
using System.Linq;
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
            Recipe foundRecipe = await _context.Recipes.Include("User").FirstOrDefaultAsync(t => t.Id == recipeId);


            if (foundRecipe != null)
            {
                var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                var isAdmin = await _userManager.IsInRoleAsync(currentUser, "admin");
                if (foundRecipe.User != currentUser && !isAdmin)
                    throw new ThisRequestNotFromOwnerException();
                Recipe mappedRecipe = _mapper.Map<UpdateRecipeRequest, Recipe>(request);
                mappedRecipe.Id = recipeId;
                foreach (var ingredientToRecipe in mappedRecipe.Ingredients.ToList())
                {

                    if (_context.Ingredients.AnyAsync(
                            u => u.Id == ingredientToRecipe.IngredientId).Result == false)
                    {
                        mappedRecipe.Ingredients.Remove(ingredientToRecipe);
                        continue;
                    }
                    ingredientToRecipe.Recipe = mappedRecipe;
                }
                _context.Entry(foundRecipe).CurrentValues.SetValues(mappedRecipe);
                foundRecipe.Tags = new List<TagsInRecipe>();
                foreach (var tag in request.Tags)
                {
                    var newTag = await _context.Tags.Include("Recipies").FirstOrDefaultAsync(u => u.Name == tag);
                    if (newTag == null)
                    {
                        //такого тега нет в системе, создадим
                        newTag = new Tag { Name = tag, Recipies = new List<TagsInRecipe>() };
                        await _context.Tags.AddAsync(newTag);
                    }
                    TagsInRecipe tit = new TagsInRecipe
                    {
                        Recipe = foundRecipe,
                        Tag = newTag
                    };
                    foundRecipe.Tags.Add(tit);
                    newTag.Recipies.Add(tit);
                    await _context.TagsInRecipies.AddAsync(tit);

                }
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
