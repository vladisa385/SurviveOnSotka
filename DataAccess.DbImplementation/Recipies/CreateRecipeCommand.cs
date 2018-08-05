﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurviveOnSotka.DataAccess.DbImplementation.Files;
using SurviveOnSotka.DataAccess.Recipies;
using SurviveOnSotka.Db;
using SurviveOnSotka.Entities;
using SurviveOnSotka.ViewModel.Recipies;

namespace SurviveOnSotka.DataAccess.DbImplementation.Recipies
{
    public class CreateRecipeCommand : ICreateRecipeCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateRecipeCommand(IMapper mapper, AppDbContext context, IHostingEnvironment appEnvironment, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _appEnvironment = appEnvironment;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<RecipeResponse> ExecuteAsync(CreateRecipeRequest request)
        {
            var recipe = _mapper.Map<CreateRecipeRequest, Recipe>(request);
            foreach (var ingredientToRecipe in recipe.Ingredients.ToList())
            {

                if (_context.Ingredients.AnyAsync(
                        u => u.Id == ingredientToRecipe.IngredientId).Result == false)
                {
                    recipe.Ingredients.Remove(ingredientToRecipe);
                    continue;
                }
                ingredientToRecipe.Recipe = recipe;
            }
            recipe.Tags = new List<TagsInRecipe>();
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
                    Recipe = recipe,
                    Tag = newTag
                };
                recipe.Tags.Add(tit);
                newTag.Recipies.Add(tit);
                await _context.TagsInRecipies.AddAsync(tit);
            }
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            recipe.User = currentUser;
            recipe.UserId = currentUser.Id;
            await _context.Recipes.AddAsync(recipe);
            if (request.Photos != null)
            {
                recipe.PathToPhotos = _appEnvironment.WebRootPath + "/Files/Recipies/" + request.Name + "/" + currentUser.Id;
                foreach (var photo in request.Photos)
                {

                    await CreateFileCommand.ExecuteAsync(photo, recipe.PathToPhotos);
                }
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Recipe, RecipeResponse>(recipe);
        }
    }
}
