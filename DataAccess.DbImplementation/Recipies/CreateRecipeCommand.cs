using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.Exceptions;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Implementanion.Recipies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurviveOnSotka.DataAccess.BaseOperation;

namespace SurviveOnSotka.DataAccess.DbImplementation.Recipies
{
    public class CreateRecipeCommand : Command<CreateRecipeRequest, RecipeResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateRecipeCommand(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
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

        protected override async Task<RecipeResponse> Execute(CreateRecipeRequest request)
        {
            var recipe = _mapper.Map<CreateRecipeRequest, Recipe>(request);
            recipe.DateCreated = DateTime.Now;
            await CreateIngredients(recipe);
            AddIdToSteps(recipe);
            await _context.Recipes.AddAsync(recipe);
            if (request.Tags != null)
                await CreateTags(recipe, request.Tags);
            await _context.SaveChangesAsync();
            return _mapper.Map<Recipe, RecipeResponse>(recipe);
        }
    }
}