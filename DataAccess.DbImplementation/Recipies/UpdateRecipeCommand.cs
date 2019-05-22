using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Exceptions;
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

        public UpdateRecipeCommand(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RecipeResponse> ExecuteAsync(UpdateRecipeRequest request)
        {
            var foundRecipe = await _context.Recipes
                .Include("User")
                .FirstOrDefaultAsync(t => t.Id == request.Id);
            if(foundRecipe == null)
                throw new UpdateItemException($"Recipe with id: {request.Id} not found");
            var mappedRecipe = _mapper.Map<UpdateRecipeRequest, Recipe>(request);
            await CreateIngredients(mappedRecipe);
            AddIdToSteps(mappedRecipe);
            await CreateTags(mappedRecipe, request.Tags);
            _context.Entry(foundRecipe).CurrentValues.SetValues(mappedRecipe);
            await _context.SaveChangesAsync();
            return _mapper.Map<Recipe, RecipeResponse>(foundRecipe);
        }
        private async Task CreateTags(Recipe recipe, ICollection<string> tags)
        {
            foreach (var tag in tags)
            {
                var newTag = await _context.Tags
                    .Include(u => u.Recipies)
                    .FirstOrDefaultAsync(u => u.Name == tag);
                if (newTag == null)
                {
                    newTag = new Tag
                    {
                        Name = tag,
                        Recipies = new List<TagsInRecipe>()
                    };
                    await _context.Tags.AddAsync(newTag);
                }
                var tit = new TagsInRecipe
                {
                    TagId = newTag.Id,
                    RecipeId = recipe.Id
                };
                await _context.TagsInRecipies.AddAsync(tit);
            }
        }
        private void AddIdToSteps(Recipe recipe) => recipe.Steps.ToList().ForEach(x => x.RecipeId = recipe.Id);
        private async Task CreateIngredients(Recipe recipe)
        {
            foreach (var ingredientToRecipe in recipe.Ingredients)
            {
                var ingredient = await _context.Ingredients
                    .FirstOrDefaultAsync(u => u.Id == ingredientToRecipe.IngredientId);
                if (ingredient == null)
                    throw new CreateItemException($"Recipe cannot be created, The ingredient with id {ingredientToRecipe.IngredientId} doesn't exist");
                ingredientToRecipe.RecipeId = recipe.Id;
            }
        }
    }
}
